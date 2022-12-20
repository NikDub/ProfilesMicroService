using MediatR;
using ProfilesMicroService.Application.Services.DTO;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByAccountIdQuery(string AccountId) : IRequest<PatientDTO>;
}
