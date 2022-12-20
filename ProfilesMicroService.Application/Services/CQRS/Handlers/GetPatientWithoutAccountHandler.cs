using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    internal class GetPatientWithoutAccountHandler : IRequestHandler<GetPatientWithoutAccountQuery, IEnumerable<PatientDTO>>
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
            var patientList = new List<Patient>();
            foreach (var patient in patientAll.Where(r=>!r.isLinkedToAccount))
            {
                int countCoefficient = 0;
                if (patient.FirstName.ToLower().Equals(request.parient.FirstName.ToLower()))
                    countCoefficient += 5;
                if (patient.LastName.ToLower().Equals(request.parient.LastName.ToLower()))
                    countCoefficient += 5;
                if (patient.MiddleName.ToLower().Equals(request.parient.MiddleName.ToLower()))
                    countCoefficient += 5;
                if (patient.DateOfBirth.Equals(request.parient.DateOfBirth))
                    countCoefficient += 3;

                if (countCoefficient >= 13)
                    patientList.Add(patient);
            }

            return _mapper.Map<List<PatientDTO>>(patientList);
        }
    }
}
