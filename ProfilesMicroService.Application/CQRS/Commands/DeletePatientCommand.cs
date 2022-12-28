using MediatR;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Commands
{
    public record DeletePatientCommand(string Id) : IRequest
    {
        public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Unit>
        {
            private readonly IPatientRepository _repository;
            public DeletePatientHandler(IPatientRepository repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                await _repository.DeleteAsync(request.Id, cancellationToken);
                return Unit.Value;
            }
        }
    }
}