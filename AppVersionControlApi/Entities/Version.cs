using AppVersionControlApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVersionControlApi.Entities
{

    [Table("versions")]
    public class Version
    {
        [Key]
        public int Id { get; set; }

        public string VersionNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        public Severity Severity { get; set; }


        [ForeignKey(nameof(Application))]
        public int ApplicationId { get; set; }
        public virtual Application? Application { get; set; } 
    }
}
