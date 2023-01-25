using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;
using SharedModel;

namespace ProfilesMicroService.Application.CQRS.Commands;

public record UpdatePatientCommand(Guid Id, PatientForUpdateDto Patient) : IRequest<PatientDto>
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly ISendEndpoint _endPoint;
        private readonly IPatientRepository _repository;

        public UpdatePatientHandler(IPatientRepository repository, IMapper mapper, IBus bus, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _endPoint = bus.GetSendEndpoint(new Uri(configuration.GetValue<string>("RabbitMQ:Uri") + configuration.GetValue<string>("RabbitMQ:QueueName:Producer:Profile"))).GetAwaiter().GetResult();
        }

        public async Task<PatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            if (request.Patient == null)
                return null;

            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (patient == null)
                return null;

            _mapper.Map(request.Patient, patient);
            await _repository.UpdateAsync(patient, cancellationToken);
            var message = new DoctorMessage
            {
                Id = request.Id,
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                MiddleName = request.Patient.MiddleName
            };
            await _endPoint.Send(message, cancellationToken);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}