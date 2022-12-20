using MediatR;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Commands
{
    public record AddPatientByPatientCommand(string AccountId, PatientForCreateDTO patient) : IRequest<PatientDTO>;
}
