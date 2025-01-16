using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Account
{
    public class ChangePasswordDTO
    {
        [Required] 
        public string CurrentPassword {  get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
