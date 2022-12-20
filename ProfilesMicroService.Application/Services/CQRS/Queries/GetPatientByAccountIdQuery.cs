using MediatR;
using ProfilesMicroService.Application.DTO.Patient;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByAccountIdQuery(string AccountId) : IRequest<PatientDTO>;
}
