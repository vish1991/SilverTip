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

        public RouteViewModels routes { get; set;}

        public SupplierTypeViewModels types { get; set; }
        //public int routeId { get; set; }
        //public int supplierTypeId { get; set; }
        //public int leafTypeId { get; set; }
        //public int bankId { get; set; }
        //public string routeName { get; set; }
        //public string leafTypeName { get; set; }
        public SupplierPaymentTypesViewModel supplierPaymentTypes { get; set; }
        public IList<SupplierFundViewModel> SupplierFunds { get; set; }
    }

    public class SupplierPaymentTypesViewModel
    {
        [Key]
        public int id { get; set; }
        public PaymentTypeViewModels paymentModes { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        //public string bankName { get; set; }
        public BankViewModels banks { get; set; }
        public string branch { get; set; }
        //public int bankId { get; set; }
        //public bool isActive { get; set; }
        //public int paymentTypeId { get; set; }
        //public int supplierId { get; set; }
        //[ForeignKey("PaymentTypeId")]
        //[ForeignKey("SupplierId")]
        //public virtual Supplier supplier { get; set; }
        //[ForeignKey("BankId")]
        //public virtual Bank bank { get; set; }
    }

    public class SupplierFundViewModel
    {
        [Key]
        public int id { get; set; }
        //public int supplierId { get; set; }
        //public int fundId { get; set; }
        //public int fundModeId { get; set; }
        public decimal fundAmount { get; set; }
        [Required]
        //public int accountNumber { get; set; }
        //public BankViewModels banks { get; set; }
        //[Required]
        //public string branch { get; set; }  
        public FundModeViewModels fundModes { get; set; }
        public FundModeViewModels fundNames { get; set; }
    }


    //public class FundsViewModel
    //{
    //    public string fundMode { get; set; }
    //    public string fundName { get; set; }
    //    public decimal amount { get; set; }
    //    [Required]
    //    public string bankName { get; set; }
    //    [Required]
    //    public int accountNo { get; set; }
    //    [Required]
    //    public string branch { get; set; }
    //    public IList<SupplierFundViewModel> supplierFunds { get; set; }

    //}

}
