using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands;

public record AddOrUpdatePatientByPatientCommand(PatientForCreateDto Patient) : IRequest<PatientDto>
{
    public class AddOrUpdatePatientByPatientHandler : IRequestHandler<AddOrUpdatePatientByPatientCommand, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public AddOrUpdatePatientByPatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            _repository.UpdateAsync(patient, cancellationToken);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}