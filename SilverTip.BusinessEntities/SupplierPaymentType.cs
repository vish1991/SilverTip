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
    class SupplierPaymntTypes
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public String Description { get; set; }
        public Boolean IsActive { get; set; }
        public String Code { get; set; }
        [ForeignKey("PaymentTypeId")]
        public virtual PaymentTypes PayementType { get; set; }

        [ForeignKey("SupplierTypeId")]
        public virtual Supplier Supplier { get; set; }


    }
}
