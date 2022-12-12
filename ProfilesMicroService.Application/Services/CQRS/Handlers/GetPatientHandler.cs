using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    internal class GetPatientHandler : IRequestHandler<GetPatientQuery, IEnumerable<Patient>>
    {
        private readonly IPatientRepository _repository;
        public GetPatientHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Patient>> Handle(GetPatientQuery request, CancellationToken cancellationToken) =>
           await _repository.GetAllAsync();
    }
}
