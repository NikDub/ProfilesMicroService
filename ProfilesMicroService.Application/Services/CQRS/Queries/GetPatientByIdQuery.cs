using MediatR;
using ProfilesMicroService.Application.DTO.Patient;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByIdQuery(string id) : IRequest<PatientDTO>;
}
