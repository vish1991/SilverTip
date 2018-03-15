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
        public int? BankId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public int PaymentTypeId { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType PayementType { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }
    }
}
