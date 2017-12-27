using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        [ForeignKey("ItemCategoryId")]
        public ItemCategory ItemCategory { get; set; }
    }
}
