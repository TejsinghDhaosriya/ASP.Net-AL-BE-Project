using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meter_API.Models
{

    [Table("meters")]
    public class Meters
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public string type { get; set; }
        public DateTime createdDate { get; set; }

        public  DateTime lastModifiedDate { get; set; }

      
    }
        
    public enum MeterType
    {
        Electricity,
        Water
    };

}
