using IdentityMicroService.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.DTO.Receptionist;
using ProfilesMicroService.Application.Services.Abstractions;

namespace ProfilesMicroService.Api.Controllers
{
    [Authorize(Roles = nameof(UserRole.Receptionist))]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly IReceptionistService _profileService;
        public ProfileController(IReceptionistService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReceptionistForCreateDTO model)
        {
            var profile = await _profileService.CreateAsync(model);
            return Ok(profile);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profile = await _profileService.GetAsync();
            return Ok(profile);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var profile = await _profileService.GetAsync(id);
            return Ok(profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ReceptionistForUpdateDTO model)
        {
            var profile = await _profileService.EditAsync(id, model);
            return Ok(profile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _profileService.DeleteAsync(id);
            return Ok();
        }
    }
}
