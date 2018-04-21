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
        public SupplierPaymentTypeViewModel supplierPaymentTypes { get; set; }
        public List<SupplierFundViewModel> supplierFunds { get; set; }
    }
    public class SupplierPaymentTypeViewModel
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
        public int supplierFundId { get; set; }
        public decimal fundAmount { get; set; }
        public FundModeViewModels fundModes { get; set; }
        public FundViewModels fundNames { get; set; }
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
        public int routesId { get; set; }
        public int typesId { get; set; }
        public bool isActive { get; set; }
        public int pageSize { get; set; }
        public int pageNum { get; set; }
        public string sortOrder { get; set; }
        public string sortColumn { get; set; }
    }
    public class SupplierGridViewModel
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string NICNo { get; set; }
        public int sRouteId { get; set; }
        public int sTypeId { get; set; }
        public bool IsActive { get; set; }
        public string route { get; set; }
        public string type { get; set; }
        public int totalRows { get; set; }
    }
    public class SupplierGridData
    {
        public int id { get; set; }
        public string registrationNo { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string contactNumber { get; set; }
        public string nicNo { get; set; }
        public bool isActive { get; set; }
        public int routeID { get; set; }
        public int typeID { get; set; }
        public string routeName { get; set; }
        public string typeName { get; set; }
        public int totalRows { get; set; }
    }

    public class UpdateSupplierPersonalDetailsViewModel
    {
        public int id { get; set; }
        public string registrationNo { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string contactNumber { get; set; }
        public RouteViewModels routes { get; set; }
        public SupplierTypeViewModels types { get; set; }
        public string nicNo { get; set; }
    }


    public class UpdateSupplierFinancialDetailsViewModel
    {
        public int id { get; set; }
        public string registrationNo { get; set; }
        public PaymentTypeViewModels paymentModes { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public BankViewModels banks { get; set; }
        public string branch { get; set; }
        public List<SupplierFundViewModel> supplierFunds { get; set; }
        
    }
}
