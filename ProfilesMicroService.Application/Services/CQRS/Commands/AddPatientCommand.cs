using MediatR;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record AddPatientCommand(Patient patient) : IRequest;
}
