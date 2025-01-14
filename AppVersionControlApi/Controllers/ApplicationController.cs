using AppVersionControlApi.Dtos.Application;
using AppVersionControlApi.Entities;
using AppVersionControlApi.Interfaces;
using AppVersionControlApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppVersionControlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly UserManager<AppUser> _userManager;

        public ApplicationController(IApplicationService applicationService, UserManager<AppUser> userManager)
        {
            _applicationService = applicationService;
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllApplications()
        {
            var applications = _applicationService.GetAllApplications().Select(x => x.ToApplicationDTO());
            return Ok(applications);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]

        public IActionResult GetApplicationById(int id)
        {
            var application = _applicationService.GetApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application.ToApplicationDTO());
        }

        [HttpPut("assignToUser")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AssignApplicationToUser(string userId, int applicationId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            if(!_applicationService.AssignApplicationToUser(userId, applicationId))
            {
                return NotFound("Application Not found or already assigned to this user");
            }
            return Ok(user);

        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public IActionResult GetApplicationsByUserId(string userId)
        {
            var applications = _applicationService.GetApplicationsByUserId(userId).Select(x => x.ToApplicationDTO());
            return Ok(applications);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult CreateApplication([FromBody] CreateApplicationDTO application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdApplication = _applicationService.CreateApplication(application.ToApplicationFromCreateApplicationDTO());
            return CreatedAtAction(nameof(GetApplicationById), new { id = createdApplication.Id }, createdApplication.ToApplicationDTO());
        }

        [HttpPut("{applicationId}/version/{versionId}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateApplicationVersion(int applicationId, int versionId)
        {
            var result = _applicationService.UpdateApplicationVersion(applicationId, versionId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteApplication(int id)
        {
            var result = _applicationService.DeleteApplication(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
