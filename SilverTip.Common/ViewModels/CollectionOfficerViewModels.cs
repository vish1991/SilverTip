using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class CollectionOfficerViewModels
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(500)]
        public string name { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public bool isActive { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
