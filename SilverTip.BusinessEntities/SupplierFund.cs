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
    public class SuppierFunds
    {
        [Key]
        public int Id { get; set; }

        public Decimal Amount { get; set; }

        [ForeignKey("SupplierId")]
        public virtual ICollection<Supplier> Suppliers { get; set; }

        [ForeignKey("FundId")]
        public virtual ICollection<Funds> Funds { get; set; }

        [ForeignKey("FundModeId")]
        public virtual ICollection<FundModes> FundModes { get; set; }

    }
}
