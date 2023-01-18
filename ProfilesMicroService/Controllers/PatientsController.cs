using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.CQRS.Commands;
using ProfilesMicroService.Application.CQRS.Queries;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Domain.Entities.Enums;

namespace ProfilesMicroService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("profile")]
    [Authorize(Roles = nameof(UserRole.Patient))]
    public async Task<IActionResult> GetProfile()
    {
        var accountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (accountId == null)
            return BadRequest("You haven't account id");

        var value = await _mediator.Send(new GetPatientByAccountIdQuery(accountId));
        if (value == null)
            return NotFound();

        return Ok(value);
    }

    [HttpPost("profile/check")]
    [Authorize(Roles = nameof(UserRole.Patient))]
    public async Task<IActionResult> FindMatchedPatientProfiles([FromBody] PatientForMatchDto model)
    {
        var patientList = await _mediator.Send(new GetPatientsWithoutLinkedAccountQuery(model));
        return Ok(patientList);
    }

    [HttpPost("profile")]
    [Authorize(Roles = nameof(UserRole.Patient))]
    public async Task<IActionResult> CreateProfileByPatient([FromBody] PatientForCreateDto model)
    {
        var patient = await _mediator.Send(new AddOrUpdatePatientByPatientCommand(model));
        return Created("", patient);
    }


    [HttpPut("{id}")]
    [Authorize(Roles = $"{nameof(UserRole.Patient)},{nameof(UserRole.Receptionist)}")]
    public async Task<IActionResult> Put(string id, [FromBody] PatientForUpdateDto model)
    {
        var result = await _mediator.Send(new UpdatePatientCommand(id, model));
        if (result == null)
            return NotFound();
        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = nameof(UserRole.Receptionist))]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetPatientQuery());
        return Ok(value);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRole.Receptionist))]
    public async Task<IActionResult> Post([FromBody] PatientForCreateDto model)
    {
        var patient = await _mediator.Send(new AddPatientByReceptionistCommand(model));
        if (patient == null)
            return BadRequest("Invalid model");

        return Created("", null);
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(UserRole.Receptionist))]
    public async Task<IActionResult> Delete(string id)
    {
        await _mediator.Send(new DeletePatientCommand(id));
        return NoContent();
    }


    [HttpGet("{id}")]
    [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Doctor)}")]
    public async Task<IActionResult> Get(string id)
    {
        var value = await _mediator.Send(new GetPatientByIdQuery(id));
        if (value == null)
            return NotFound();
        return Ok(value);
    }
}