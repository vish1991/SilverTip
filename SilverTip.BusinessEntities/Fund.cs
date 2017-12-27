using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class Fund
    {
        public Fund()
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
        public int BankId { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsActive { get; set; }  
        public int AccountNumber { get; set; }
        public string Branch { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("BankId")]
        public Bank Bank { get; set; }

        public virtual ICollection<SupplierFund> SupplierFunds { get; set; }
    }
}