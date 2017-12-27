using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class PaymentType
    {
        public PaymentType()
        {
            SupplierPaymentTypes = new HashSet<SupplierPaymentType>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<SupplierPaymentType> SupplierPaymentTypes { get; set; }

    }

}