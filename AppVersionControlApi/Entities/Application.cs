using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVersionControlApi.Entities
{
    [Table("applications")]
    public class Application
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        
        public string Description { get; set; }

        public int? CurrentVersionId { get; set; }
        public virtual IEnumerable<Version> Versions { get; set; } = new List<Version>().AsEnumerable();
        public virtual IEnumerable<UserApplication> Users { get; set; } = new List<UserApplication>().AsEnumerable();
    }
}
