using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Commands;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
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
            if(patient == null) 
                return null;

            _mapper.Map(request.patient, patient);
            _repository.Update(patient);
            await _repository.SaveAsync();
            return _mapper.Map<PatientDTO>(patient);
        }
    }
}