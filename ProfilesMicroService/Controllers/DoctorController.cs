using IdentityMicroService.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Enums;

namespace ProfilesMicroService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("AtWork")]
        public async Task<IActionResult> GetAtWork()
        {
            var doctorList = await _doctorService.GetDoctorsByStatusAsync(nameof(StatusEnum.AtWork));
            return Ok(doctorList);
        }

        [Authorize(Roles = nameof(UserRole.Patient))]
        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [Authorize(Roles = nameof(UserRole.Doctor))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }

        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoctorForCreateDTO model)
        {
            var doctor = await _doctorService.CreateAsync(model);
            if (doctor == null)
                return BadRequest();
            return Created("", doctor);
        }

        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [Authorize(Roles = nameof(UserRole.Doctor))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] DoctorForUpdateDTO model)
        {
            var doctor = await _doctorService.UpdateAsync(id, model);
            if (doctor == null)
                return NotFound();
            return NoContent();
        }

        [Authorize(Roles = nameof(UserRole.Receptionist))]
        [HttpPut("{id}/status/{status}")]
        public async Task<IActionResult> PutStatus(string id, string status)
        {
            var doctor = await _doctorService.ChangeStatusAsync(id, status);
            if (doctor == null)
                return NotFound();
            return NoContent();
        }

    }
}
