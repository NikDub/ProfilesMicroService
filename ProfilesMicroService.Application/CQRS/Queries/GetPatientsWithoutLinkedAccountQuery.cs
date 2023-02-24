using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Queries;

public record GetPatientsWithoutLinkedAccountQuery(PatientForMatchDto Patient) : IRequest<PatientDto>
{
    public class
        GetPatientsWithoutLinkedAccountHandler : IRequestHandler<GetPatientsWithoutLinkedAccountQuery, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public GetPatientsWithoutLinkedAccountHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(GetPatientsWithoutLinkedAccountQuery request,
            CancellationToken cancellationToken)
        {
            var patientList = (await _repository.GetAllWithoutAccountAsync(cancellationToken))
                .FirstOrDefault(patient => IsMatchPatient(patient, request.Patient));

            return _mapper.Map<PatientDto>(patientList);
        }

        private bool IsMatchPatient(Patient patient, PatientForMatchDto requestPatient)
        {
            var countCoefficient = 0;
            if (IsEquals(patient.FirstName, requestPatient.FirstName))
                countCoefficient += 5;
            if (IsEquals(patient.LastName, requestPatient.LastName))
                countCoefficient += 5;
            if (IsEquals(patient.MiddleName, requestPatient.MiddleName))
                countCoefficient += 5;
            if (patient.DateOfBirth.Equals(requestPatient.DateOfBirth))
                countCoefficient += 3;

            return countCoefficient >= 13;
        }

        private bool IsEquals(string str1, string str2)
        {
            return str1.ToLower().Equals(str2.ToLower());
        }
    }
}