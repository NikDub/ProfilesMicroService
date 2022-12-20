using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record UpdatePatientCommand(string id, PatientForUpdateDTO patient) : IRequest<PatientDTO>
    {
        public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, PatientDTO>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public UpdatePatientHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                this._mapper = mapper;
            }

            public async Task<PatientDTO> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
            {
                if (request.patient == null)
                    return null;

                var patient = await _repository.GetByIdAsync(request.id);
                if (patient == null)
                    return null;

                _mapper.Map(request.patient, patient);
                _repository.Update(patient);
                await _repository.SaveAsync();
                return _mapper.Map<PatientDTO>(patient);
            }
        }
    }
}
