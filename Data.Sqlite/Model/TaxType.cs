using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Sqlite.Model
{
    [Table("TaxTypes")]
    public class TaxType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxTypeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }
}
