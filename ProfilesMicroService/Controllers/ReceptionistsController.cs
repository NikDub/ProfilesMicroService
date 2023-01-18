using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.Dto.Receptionist;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Enums;

namespace ProfilesMicroService.Api.Controllers;

[Authorize(Roles = nameof(UserRole.Receptionist))]
[Route("api/[controller]")]
public class ReceptionistsController : Controller
{
    private readonly IReceptionistService _profileService;

    public ReceptionistsController(IReceptionistService profileService)
    {
        _profileService = profileService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReceptionistForCreateDto model)
    {
        var profile = await _profileService.CreateAsync(model);
        if (profile == null)
            return BadRequest("Invalid model");

        return Created("", profile);
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
        var profile = await _profileService.GetByIdAsync(id);
        if (profile == null)
            return NotFound();

        return Ok(profile);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] ReceptionistForUpdateDto model)
    {
        var profile = await _profileService.UpdateAsync(id, model);
        if (profile == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _profileService.DeleteAsync(id);
        return NoContent();
    }
}