using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meter_API.Models
{
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long id;

        private string name;

        private bool active;
        
        private DateTime createdDate;

        private DateTime lastModifiedDate;
    }
}
