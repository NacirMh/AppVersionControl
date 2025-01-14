using System.ComponentModel.DataAnnotations;

namespace AppVersionControlApi.Entities
{
    public class User : AppUser
    {
        public virtual IEnumerable<UserApplication> Applications { get; set; } = new List<UserApplication>().AsEnumerable();
    }
}
