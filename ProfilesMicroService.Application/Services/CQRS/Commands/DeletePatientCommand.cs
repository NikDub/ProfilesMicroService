using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record DeletePatientCommand(string id) : IRequest
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
                await _repository.DeleteAsync(request.id);
                await _repository.SaveAsync();
                return Unit.Value;
            }
        }
    }
}
