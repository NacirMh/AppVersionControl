using AppVersionControlApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Version
{
    public class CreateVersionDTO
    {
        [Required]
        public string VersionNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Severity Severity { get; set; }

        [Required]
        public int ApplicationId { get; set; }
    }
}
