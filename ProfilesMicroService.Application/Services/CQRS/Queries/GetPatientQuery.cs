using MediatR;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientQuery() : IRequest<IEnumerable<PatientDTO>>;
}
