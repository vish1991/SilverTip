using Boughtleaf.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierFunds = new HashSet<SupplierFund>();
            SupplierPaymentTypes = new HashSet<SupplierPaymentType>();
            SupplierCollections = new HashSet<SupplierCollection>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RegNo { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactNo { get; set; }
        public string Notes { get; set; }
        [StringLength(20)]
        public string NICNo { get; set; }
        public int RouteId { get; set; }
        public int SupplierTypeId { get; set; }
        public int LeafTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }
        [ForeignKey("SupplierTypeId")]
        public virtual SupplierType SupplierType { get; set; }
        [ForeignKey("LeafTypeId")]
        public virtual LeafType LeafType { get; set; }
        public virtual ICollection<SupplierFund> SupplierFunds { get; set; }
        public virtual ICollection<SupplierPaymentType> SupplierPaymentTypes { get; set; }
        public virtual ICollection<SupplierCollection> SupplierCollections { get; set; }
    }
}
