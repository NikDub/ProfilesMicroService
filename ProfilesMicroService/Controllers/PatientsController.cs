using IdentityMicroService.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.CQRS.Commands;
using ProfilesMicroService.Application.CQRS.Queries;
using ProfilesMicroService.Application.DTO.Patient;
using System.Security.Claims;

namespace ProfilesMicroService.Api.Controllers
{
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
            var AccountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (AccountId == null)
                return BadRequest("You haven't account id");

            var value = await _mediator.Send(new GetPatientByAccountIdQuery(AccountId));
            if (value == null)
                return NotFound();

            return Ok(value);
        }

        [HttpPost("profile/check")]
        [Authorize(Roles = nameof(UserRole.Patient))]
        public async Task<IActionResult> GetProfileWithoutAccount([FromBody] PatientForCreateDTO model)
        {
            var patientList = await _mediator.Send(new GetPatientWithoutAccountQuery(model));
            return Ok(patientList);
        }

        [HttpPost("profile")]
        [Authorize(Roles = nameof(UserRole.Patient))]
        public async Task<IActionResult> CreateProfileByPatient([FromBody] PatientForCreateDTO model)
        {
            var AccountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (AccountId == null)
                return BadRequest("You haven't account id");

            await _mediator.Send(new AddPatientByPatientCommand(AccountId, model));
            return Created("", null);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Patient)},{nameof(UserRole.Receptionist)}")]
        public async Task<IActionResult> Put(string id, [FromBody] PatientForUpdateDTO model)
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
        public async Task<IActionResult> Post([FromBody] PatientForCreateDTO model)
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
}
