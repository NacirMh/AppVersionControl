using AppVersionControlApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppVersionControlApi.Dtos.Version;

namespace AppVersionControlApi.Dtos.Application
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? CurrentVersionId { get; set; }
        public IEnumerable<VersionDTO> Versions { get; set; } = new List<VersionDTO>();

    }
}
