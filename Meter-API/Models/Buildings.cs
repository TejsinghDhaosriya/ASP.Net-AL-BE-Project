using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meter_API.Models
{

    [Table("buildings")]
    public class Buildings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public  ICollection<Floors> floors { get; set; }
        public DateTime createdDate { get; set; }

        public  DateTime lastModifiedDate { get; set; }
    }
}
