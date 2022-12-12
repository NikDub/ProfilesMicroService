using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.Services.CQRS.Commands;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using ProfilesMicroService.Domain.Entities.Models;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetPatientQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetPatientByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Patient model) // to do
        {
            await _mediator.Send(new AddPatientCommand(model));
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Patient model) // to do
        {
            var result = await _mediator.Send(new UpdatePatientCommand(model));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeletePatientCommand(id));
            return Ok();
        }
    }
}
