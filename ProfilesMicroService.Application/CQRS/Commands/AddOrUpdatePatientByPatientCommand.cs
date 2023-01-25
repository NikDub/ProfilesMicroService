using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;
using SharedModel;

namespace ProfilesMicroService.Application.CQRS.Commands;

public record AddOrUpdatePatientByPatientCommand(PatientForCreateDto Patient) : IRequest<PatientDto>
{
    public class AddOrUpdatePatientByPatientHandler : IRequestHandler<AddOrUpdatePatientByPatientCommand, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly ISendEndpoint _endPoint;
        private readonly IPatientRepository _repository;

        public AddOrUpdatePatientByPatientHandler(IPatientRepository repository, IMapper mapper, IBus bus, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _endPoint = bus.GetSendEndpoint(new Uri(configuration.GetValue<string>("RabbitMQ:Uri") + configuration.GetValue<string>("RabbitMQ:QueueName:Producer:Profile:Patient"))).GetAwaiter().GetResult();
        }

        public async Task<PatientDto> Handle(AddOrUpdatePatientByPatientCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Patient == null)
                return null;
            var patient = await _repository.GetByAccountIdAsync(request.Patient.AccountId, cancellationToken);
            if (patient == null)
            {
                var patientMap = _mapper.Map<Patient>(request.Patient);
                patientMap.IsLinkedToAccount = true;
                await _repository.InsertAsync(patientMap, cancellationToken);
                return _mapper.Map<PatientDto>(patientMap);
            }

            _mapper.Map(patient, request.Patient);
            await _repository.UpdateAsync(patient, cancellationToken);
            var message = new PatientMessage
            {
                Id = patient.Id,
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                MiddleName = request.Patient.MiddleName
            };
            await _endPoint.Send(message, cancellationToken);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}