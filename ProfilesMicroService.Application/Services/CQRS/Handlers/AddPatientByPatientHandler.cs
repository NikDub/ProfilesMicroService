using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Commands;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    public class AddPatientByPatientHandler : IRequestHandler<AddPatientByPatientCommand, PatientDTO>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public AddPatientByPatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDTO> Handle(AddPatientByPatientCommand request, CancellationToken cancellationToken)
        {
            if (request.patient == null)
                return null;

            var patient = _mapper.Map<Patient>(request.patient);
            patient.AccountId = request.AccountId;
            patient.isLinkedToAccount = true;
            await _repository.InsertAsync(patient);
            await _repository.SaveAsync();

            return _mapper.Map<PatientDTO>(patient);
        }
    }
}
