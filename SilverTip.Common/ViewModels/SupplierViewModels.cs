using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string registrationNo { get; set; }
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
        public string contactNumber { get; set; }
        public string notes { get; set; }
        [StringLength(20)]
        public string nicNo { get; set; }
        public LeafTypeViewModels leafTypes { get; set; }
        public RouteViewModels routes { get; set; }
        public SupplierTypeViewModels types { get; set; }
        public SupplierPaymentTypesViewModel supplierPaymentTypes { get; set; }
        public IEnumerable<SupplierFundViewModel> supplierFunds { get; set; }
    }
    public class SupplierPaymentTypesViewModel
    {
        [Key]
        public int id { get; set; }
        public PaymentTypeViewModels paymentModes { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public BankViewModels banks { get; set; }
        public string branch { get; set; }
    }
    public class SupplierFundViewModel
    {
        [Key]
        public int id { get; set; }
        public decimal fundAmount { get; set; }
        public FundModeViewModels fundModes { get; set; }
        public FundModeViewModels fundNames { get; set; }
    }
    public class SupplierGridSearchCriteriaViewModel
    {
        public int id { get; set; }
        [StringLength(50)]
        public string registrationNo { get; set; }
        [StringLength(200)]
        public string fullName { get; set; }
        [StringLength(500)]
        public string address { get; set; }
        public int routeId { get; set; }
        public int typeId { get; set; }
        public bool isActive { get; set; }
        public int pageSize { get; set; }
        public int pageNum { get; set; }
        public string sortOrder { get; set; }
        public string sortColumn { get; set; }
    }
    public class SupplierGridViewModel
    {
        public string registrationNo { get; set; }
        public string fullName { get; set; }
        public bool isActive { get; set; }
        public string routeName { get; set; }
        public string typeName { get; set; }
        public int totalRows { get; set; }
    }
    public class SupplierGridData
    {
        public string registrationNo { get; set; }
        public string fullName { get; set; }
        public bool isActive { get; set; }
        public string routeName { get; set; }
        public string typeName { get; set; }
        public int totalRows { get; set; }
    }
}
