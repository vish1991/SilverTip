using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ItemCategoryId")]
        public virtual ICollection<ItemCategories> ItemCategories { get; set; }
    }
}
