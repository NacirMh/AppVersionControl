using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Account
{
    public class ResetPasswordDTO
    {

        [Required]
        public string UserId { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
