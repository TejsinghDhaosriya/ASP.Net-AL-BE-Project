using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meter_API.Models
{

    [Table("cities")]
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public int pincode { get; set; }

        public ICollection<Facilities> facilities { get; set; }
        public DateTime createdDate { get; set; }

        public  DateTime lastModifiedDate { get; set; }
    }
}
