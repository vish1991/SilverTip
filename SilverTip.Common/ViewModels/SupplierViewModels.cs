using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class SupplierFormViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string regNo { get; set; }
        [Required]
        [StringLength(200)]
        public string fullName { get; set; }
        [Required]
        [StringLength(500)]
        public string address { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        [StringLength(100)]
        public string contactNo { get; set; }
        public string notes { get; set; }
        [StringLength(20)]
        public string nicNo { get; set; }
        public int routeId { get; set; }
        public int supplierTypeId { get; set; }
        public int leafTypeId { get; set; }
        public int bankId { get; set; }
        public IList<SupplierPaymentType> supplierPaymentTypes { get; set; }
    }

    public class SupplierPaymentType
    {
        public int bankId { get; set; }
        public string accountNo { get; set; }
    }
}
