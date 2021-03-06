﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class LeafTypeViewModels
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string code { get; set; }
        [Required]
        [MaxLength(200)]
        public string name { get; set; }
        [Required]
        public bool isActive { get; set; }
    }
}
