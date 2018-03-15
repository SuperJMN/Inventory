using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Sqlite.Model
{
    [Table("Shippers")]
    public class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShipperID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
