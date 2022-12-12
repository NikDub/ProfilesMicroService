using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Commands;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    public class AddPatientHandler : IRequestHandler<AddPatientCommand, Unit>
    {
        private readonly IPatientRepository _repository;
        public AddPatientHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(request.patient);
            await _repository.SaveAsync();
            return Unit.Value;
        }
    }
}
