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
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("AtWork")]
        public async Task<IActionResult> GetAtWork()
        {
            var doctorList = await _doctorService.GetDoctorsByStatusAsync(nameof(StatusEnum.AtWork));
            return Ok(doctorList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Patient)},{nameof(UserRole.Receptionist)},{nameof(UserRole.Doctor)}")]
        public async Task<IActionResult> Get(string id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Receptionist))]
        public async Task<IActionResult> Create([FromBody] DoctorForCreateDTO model)
        {
            var doctor = await _doctorService.CreateAsync(model);
            if (doctor == null)
                return BadRequest("Invalid model");
            return Created("", doctor);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Doctor)}")]
        public async Task<IActionResult> Put(string id, [FromBody] DoctorForUpdateDTO model)
        {
            var doctor = await _doctorService.UpdateAsync(id, model);
            if (doctor == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/status/{status}")]
        [Authorize(Roles = nameof(UserRole.Receptionist))]
        public async Task<IActionResult> PutStatus(string id, string status)
        {
            var doctor = await _doctorService.ChangeStatusAsync(id, status);
            if (doctor == null)
                return NotFound();
            return NoContent();
        }

    }
}
