using IdentityMicroService.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.CQRS.Commands;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using System.Security.Claims;

namespace ProfilesMicroService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = nameof(UserRole.Patient))]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var AccountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (AccountId == null)
                return BadRequest();

            var value = await _mediator.Send(new GetPatientByAccountIdQuery(AccountId));
            if (value == null)
                return NotFound();

            return Ok(value);
        }

        [Authorize(Roles = nameof(UserRole.Patient))]
        [HttpPost("profile/check")]
        public async Task<IActionResult> GetProfileWithoutAccount([FromBody] PatientForCreateDTO model)
        {
            var patientList = await _mediator.Send(new GetPatientWithoutAccountQuery(model));
            return Ok(patientList);
        }

        [Authorize(Roles = nameof(UserRole.Patient))]
        [HttpPost("profile")]
        public async Task<IActionResult> CreateProfileByPatient([FromBody] PatientForCreateDTO model)
        {
            var AccountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (AccountId == null)
                return BadRequest();

            await _mediator.Send(new AddPatientByPatientCommand(AccountId, model));
            return Created("", null);
        }


        [Authorize(Roles = nameof(UserRole.Patient))]
        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] PatientForUpdateDTO model)
        {
            var result = await _mediator.Send(new UpdatePatientCommand(id, model));
            if (result == null)
                return NotFound();
            return NoContent();
        }

        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetPatientQuery());
            return Ok(value);
        }

        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientForCreateDTO model)
        {
            var patient = await _mediator.Send(new AddPatientByReceptionistCommand(model));
            if (patient == null)
                return BadRequest();

            return Created("", null);
        }


        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeletePatientCommand(id));
            return NoContent();
        }


        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [Authorize(Roles = nameof(UserRole.Doctor))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetPatientByIdQuery(id));
            if (value == null)
                return NotFound();
            return Ok(value);
        }
    }
}
