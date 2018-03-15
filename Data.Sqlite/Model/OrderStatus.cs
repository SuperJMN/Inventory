using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Sqlite.Model
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
