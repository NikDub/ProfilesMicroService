using MediatR;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientWithoutAccountQuery(PatientForCreateDTO parient) : IRequest<IEnumerable<PatientDTO>>;
}
