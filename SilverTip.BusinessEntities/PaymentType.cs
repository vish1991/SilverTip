using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boughtleaf.BusinessEntities
{
    public class PaymentTypes
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        [MaxLength(500)]
        public String Description { get; set; }
        public Boolean IsActive { get; set; }
        public String Code { get; set; }
        public DateTime Date { get; set; }

    }

}