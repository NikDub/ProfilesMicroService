using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands
{
    public record AddPatientByPatientCommand(string AccountId, PatientForCreateDTO Patient) : IRequest<PatientDTO>
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
                if (request.Patient == null)
                    return null;

                var patient = _mapper.Map<Patient>(request.Patient);
                patient.AccountId = request.AccountId;
                patient.IsLinkedToAccount = true;
                await _repository.InsertAsync(patient, cancellationToken);

                return _mapper.Map<PatientDTO>(patient);
            }
        }
    }
}