using MediatR;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record AddPatientByReceptionistCommand(PatientForCreateDTO patient) : IRequest<PatientDTO>;
}
