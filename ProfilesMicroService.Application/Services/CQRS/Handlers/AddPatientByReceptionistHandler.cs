using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Commands;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    public class AddPatientByReceptionistHandler : IRequestHandler<AddPatientByReceptionistCommand, PatientDTO>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public AddPatientByReceptionistHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDTO> Handle(AddPatientByReceptionistCommand request, CancellationToken cancellationToken)
        {
            if (request.patient == null)
                return null;

            var patient = _mapper.Map<Patient>(request.patient);
            patient.isLinkedToAccount = false;
            await _repository.InsertAsync(patient);
            await _repository.SaveAsync();

            return _mapper.Map<PatientDTO>(patient);
        }
    }
}
