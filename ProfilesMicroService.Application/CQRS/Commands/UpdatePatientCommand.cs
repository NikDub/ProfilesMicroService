using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands;

public record UpdatePatientCommand(string Id, PatientForUpdateDto Patient) : IRequest<PatientDto>
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public UpdatePatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            return _mapper.Map<PatientDto>(patient);
        }
    }
}