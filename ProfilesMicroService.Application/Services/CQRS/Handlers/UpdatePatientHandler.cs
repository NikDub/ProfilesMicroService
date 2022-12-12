using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Commands;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Patient>
    {
        private readonly IPatientRepository _repository;
        public UpdatePatientHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.patient);
            await _repository.SaveAsync();
            return request.patient;
        }
    }
}