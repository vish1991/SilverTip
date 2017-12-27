using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public class CollectionOfficer
    {
        public CollectionOfficer()
        {
            LeafCollections = new HashSet<LeafCollection>();
            SupplierCollections = new HashSet<SupplierCollection>();
            CollectionOfficerRoutes = new HashSet<CollectionOfficerRoute>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<LeafCollection> LeafCollections { get; set; }
        public virtual ICollection<SupplierCollection> SupplierCollections { get; set; }
        public virtual ICollection<CollectionOfficerRoute> CollectionOfficerRoutes { get; set; }

    }
}
