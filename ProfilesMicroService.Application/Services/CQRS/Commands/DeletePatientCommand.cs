using MediatR;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record DeletePatientCommand(string id) : IRequest;
}
