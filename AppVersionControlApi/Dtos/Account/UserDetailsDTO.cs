using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Dtos.Account
{
    public class UserDetailsDTO
    {

        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
