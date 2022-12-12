using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, Patient>
    {
        private readonly IPatientRepository _repository;
        public GetPatientByIdHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.id);
        }
    }
}
