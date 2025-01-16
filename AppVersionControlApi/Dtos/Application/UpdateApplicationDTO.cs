using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Application
{
    public class UpdateApplicationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
