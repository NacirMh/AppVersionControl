using AppVersionControlApi.Dtos.Version;
using AppVersionControlApi.Interfaces;
using AppVersionControlApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Version = AppVersionControlApi.Entities.Version;

namespace AppVersionControlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IVersionService _versionService;

        public VersionController(IVersionService versionService)
        {
            _versionService = versionService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="admin")]

        public IActionResult GetVersionById(int id)
        {
            var version = _versionService.GetVersionById(id);
            if (version == null)
                return NotFound();
            return Ok(version.ToVersionDTO());
        }

        [HttpGet("App/{appId}")]
        [Authorize]
        public IActionResult GetVersionsByAppId(int appId)
        {
            var versions = _versionService.GetVersionsByAppId(appId).Select(x=>x.ToVersionDTO());
            if (versions == null || !versions.Any())
                return NotFound();
            return Ok(versions);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]

        public IActionResult AddVersion([FromBody] CreateVersionDTO version)
        {
            if (version == null)
                return BadRequest();

            var createdVersion = _versionService.AddVersion(version.ToVersionFromCreateVersionDTO());
            return CreatedAtAction(nameof(GetVersionById), new { id = createdVersion.Id }, createdVersion);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]

        public IActionResult UpdateVersion(int id, [FromBody] UpdateVersionDTO version)
        {
            if (version == null )
                return BadRequest();

            var updatedVersion = _versionService.UpdateVersion(version.ToVersionFromUpdateVersionDTO(id));
            if (updatedVersion == null)
                return NotFound();

            return Ok(updatedVersion);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteVersion(int id)
        {
            var isDeleted = _versionService.DeleteVersion(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
