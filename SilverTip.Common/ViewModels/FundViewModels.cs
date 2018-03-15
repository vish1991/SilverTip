using Boughtleaf.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class FundViewModels
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string code { get; set; }
        [Required]
        [MaxLength(200)]
        public string name { get; set; }
        public int bankId { get; set; }
        [MaxLength(500)]
        public string description { get; set; }
        public bool isActive { get; set; }
        public int accountNumber { get; set; }
        public string branch { get; set; }
        [ForeignKey("BankId")]
        public Bank bank { get; set; }
    }
}
