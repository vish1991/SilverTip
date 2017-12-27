using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class FundMode
    {
        public FundMode()
        {
            SupplierFunds = new HashSet<SupplierFund>();
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
        public virtual ICollection<SupplierFund> SupplierFunds { get; set; }
    }
}