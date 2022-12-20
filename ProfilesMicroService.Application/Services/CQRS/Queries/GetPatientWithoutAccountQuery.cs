using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientWithoutAccountQuery(PatientForCreateDTO parient) : IRequest<IEnumerable<PatientDTO>>
    {
        public class GetPatientWithoutAccountHandler : IRequestHandler<GetPatientWithoutAccountQuery, IEnumerable<PatientDTO>>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public GetPatientWithoutAccountHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<PatientDTO>> Handle(GetPatientWithoutAccountQuery request, CancellationToken cancellationToken)
            {
                var patientAll = await _repository.GetAllAsync();
                var patientList = patientAll.Where(r => !r.isLinkedToAccount)
                    .Select(patient => isMatchPatient(patient, request.parient) ? patient : null);

                return _mapper.Map<List<PatientDTO>>(patientList);
            }

            private bool isMatchPatient(Patient patient, PatientForCreateDTO requestPatient)
            {
                int countCoefficient = 0;
                if (patient.FirstName.ToLower().Equals(requestPatient.FirstName.ToLower()))
                    countCoefficient += 5;
                if (patient.LastName.ToLower().Equals(requestPatient.LastName.ToLower()))
                    countCoefficient += 5;
                if (patient.MiddleName.ToLower().Equals(requestPatient.MiddleName.ToLower()))
                    countCoefficient += 5;
                if (patient.DateOfBirth.Equals(requestPatient.DateOfBirth))
                    countCoefficient += 3;

                if (countCoefficient >= 13)
                    return true;

                return false;
            }
        }
    }
}
