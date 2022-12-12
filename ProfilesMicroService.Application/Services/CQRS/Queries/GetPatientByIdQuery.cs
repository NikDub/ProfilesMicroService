using MediatR;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByIdQuery(string id) : IRequest<Patient>;
}
