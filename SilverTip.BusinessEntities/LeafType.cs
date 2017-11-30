using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public partial class LeafType
    {
        public LeafType()
        {
            Suppliers = new HashSet<Supplier>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
