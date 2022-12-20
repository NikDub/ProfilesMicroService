using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record AddPatientByReceptionistCommand(PatientForCreateDTO patient) : IRequest<PatientDTO>;
}
