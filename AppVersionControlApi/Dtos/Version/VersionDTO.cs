using AppVersionControlApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Version
{
    public class VersionDTO
    {
        public int Id { get; set; }

        public string VersionNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime UpdateDate { get; set; }

       
        public Severity Severity { get; set; }

        public int ApplicationId { get; set; }
         

    }
}
