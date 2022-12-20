using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Commands;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    internal class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Unit>
    {
        private readonly IPatientRepository _repository;
        public DeletePatientHandler(IPatientRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id);
            await _repository.SaveAsync();
            return Unit.Value;
        }
    }
}
