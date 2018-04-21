using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class FundModeViewModels
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string code { get; set; }
        [MaxLength(200)]
        public string name { get; set; }
        public bool isActive { get; set; }
    }
}
