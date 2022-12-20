using MediatR;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record UpdatePatientCommand(string id,PatientForUpdateDTO patient) : IRequest<PatientDTO>;
}
