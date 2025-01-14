using System.ComponentModel.DataAnnotations.Schema;

namespace AppVersionControlApi.Entities
{
    public class UserApplication
    {

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Application))]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
