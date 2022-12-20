using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record UpdatePatientCommand(string id,PatientForUpdateDTO patient) : IRequest<PatientDTO>;
}
