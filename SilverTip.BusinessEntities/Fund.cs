using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class Funds
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        [MaxLength(500)]
        public String Description { get; set; }
        public Boolean IsActive { get; set; }
        public String Code { get; set; }
        public int AccountNumber { get; set; }
        public String Branch { get; set; }
        [ForeignKey("BankId")]
        public Banks Bank { get; set; }
    }
}