using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientWithoutAccountQuery(PatientForCreateDTO parient) : IRequest<IEnumerable<PatientDTO>>;
}
