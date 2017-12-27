using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class SupplierPaymentType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int PaymentTypeId { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType PayementType { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}
