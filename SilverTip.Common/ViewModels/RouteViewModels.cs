using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class RouteViewModels
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public bool isActive { get; set; }

    }
}
