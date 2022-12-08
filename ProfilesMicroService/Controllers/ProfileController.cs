﻿using Microsoft.AspNetCore.Mvc;
using ProfilesMicroService.Application.Services;
using ProfilesMicroService.Application.Services.Abstractions;

namespace ProfilesMicroService.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

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
        public async Task<IActionResult> Update(string id, ProfileDTO model)
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