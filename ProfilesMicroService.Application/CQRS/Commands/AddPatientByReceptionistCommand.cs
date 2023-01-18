using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands;

public record AddPatientByReceptionistCommand(PatientForCreateDto Patient) : IRequest<PatientDto>
{
    public class AddPatientByReceptionistHandler : IRequestHandler<AddPatientByReceptionistCommand, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public AddPatientByReceptionistHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(AddPatientByReceptionistCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Patient == null)
                return null;

            var patient = _mapper.Map<Patient>(request.Patient);
            patient.IsLinkedToAccount = false;
            await _repository.InsertAsync(patient, cancellationToken);

            return _mapper.Map<PatientDto>(patient);
        }
    }
}