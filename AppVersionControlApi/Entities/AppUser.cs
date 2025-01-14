using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Entities
{
    public class AppUser : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }
    }
}
