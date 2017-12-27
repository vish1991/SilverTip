using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public partial class Route
    {
        public Route()
        {
            Suppliers = new HashSet<Supplier>();
            CollectionOfficers = new HashSet<CollectionOfficer>();
            LeafCollections = new HashSet<LeafCollection>();
            SupplierCollections = new HashSet<SupplierCollection>();
            CollectionOfficerRoutes = new HashSet<CollectionOfficerRoute>();
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
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<CollectionOfficer> CollectionOfficers { get; set; }
        public virtual ICollection<LeafCollection> LeafCollections { get; set; }
        public virtual ICollection<SupplierCollection> SupplierCollections { get; set; }
        public virtual ICollection<CollectionOfficerRoute> CollectionOfficerRoutes { get; set; }

    }
}
