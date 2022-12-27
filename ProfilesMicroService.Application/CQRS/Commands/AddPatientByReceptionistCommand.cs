using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands
{
    public record AddPatientByReceptionistCommand(PatientForCreateDTO Patient) : IRequest<PatientDTO>;
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
            if (request.Patient == null)
                return null;

            var patient = _mapper.Map<Patient>(request.Patient);
            patient.isLinkedToAccount = false;
            await _repository.InsertAsync(patient, cancellationToken);

            return _mapper.Map<PatientDTO>(patient);
        }
    }
}
