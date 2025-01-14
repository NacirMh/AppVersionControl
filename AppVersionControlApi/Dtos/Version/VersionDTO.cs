using AppVersionControlApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Version
{
    public class VersionDTO
    {
        public int Id { get; set; }

        [Required]
        public string VersionNumber { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public Severity Severity { get; set; }

        [Required]
        public int ApplicationId { get; set; }
         

    }
}
