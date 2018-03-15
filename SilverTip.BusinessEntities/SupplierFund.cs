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
    public class SupplierFund
    {
        [Key]
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public int FundId {get; set;}

        public int FundModeId { get; set; }
    
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        [ForeignKey("FundId")]
        public Fund Fund { get; set; }

        [ForeignKey("FundModeId")]
        public FundMode FundMode { get; set; }

    }
}
