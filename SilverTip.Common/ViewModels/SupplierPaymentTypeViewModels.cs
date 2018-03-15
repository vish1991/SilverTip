using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class SupplierPaymentTypeViewModels
    {
        [Key]
        public int id { get; set; }
        public int? bankId { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public string branch { get; set; }
        public bool isActive { get; set; }
        public int paymentTypeId { get; set; }
        public int supplierId { get; set; }
        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType payementType { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier supplier { get; set; }
        [ForeignKey("BankId")]
        public virtual Bank bank { get; set; }
        public string bankName { get; set; }
    }
}
