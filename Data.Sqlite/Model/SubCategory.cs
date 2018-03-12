﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Sqlite.Model
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key]
        [DatabaseGenerat‌​ed(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerat‌​ed(DatabaseGeneratedOption.None)]
        public int SubCategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }
    }
}
