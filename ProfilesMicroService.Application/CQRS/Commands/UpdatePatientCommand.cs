using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands
{
    public record UpdatePatientCommand(string Id, PatientForUpdateDTO Patient) : IRequest<PatientDTO>;
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, PatientDTO>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDTO> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            if (request.Patient == null)
                return null;

            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (patient == null)
                return null;

            _mapper.Map(request.Patient, patient);
            await _repository.UpdateAsync(patient, cancellationToken);
            return _mapper.Map<PatientDTO>(patient);
        }
    }
}
