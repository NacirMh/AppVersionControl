using AppVersionControlApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AppVersionControlApi.Dtos.Version;
using AppVersionControlApi.Dtos.Account;

namespace AppVersionControlApi.Dtos.Application
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public int? CurrentVersionId { get; set; }
        public IEnumerable<VersionDTO> Versions { get; set; } = new List<VersionDTO>();
        public IEnumerable<UserDetailsDTO> Users { get; set; } = new List<UserDetailsDTO>();

    }
}
