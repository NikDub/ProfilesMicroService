using MediatR;
using ProfilesMicroService.Application.Services.DTO;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByIdQuery(string id) : IRequest<PatientDTO>;
}
