using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Meter_API.Models
{

    [Table("zones")]
    public class Zones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public ICollection<Meters> meters { get; set; }
        public DateTime createdDate { get; set; }

        public  DateTime lastModifiedDate { get; set; }
    }
}
