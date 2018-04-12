using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class SupplierFundViewModels
    {
        public decimal fundAmount { get; set; }
        public int supplierId { get; set; }
        public int fundId { get; set; }
        public int fundModeId { get; set; }
        public SupplierViewModel supplier { get; set; }
        public FundViewModel fundNames { get; set; }
        public FundModeViewModel fundModes { get; set; }
        public List<SupplierFundUpdateViewModel> supplierFunds { get;set;}
    }

    public class FundModeViewModel
    {
        public string name { get; set; }
    }

    public class FundViewModel
    {
        public string name { get; set; }
    }

    public class SupplierViewModel
    {
        public int id { get; set; }
    }

    public class SupplierFundUpdateViewModel
    {
        [Key]
        public int id { get; set; }
        public decimal fundAmount { get; set; }
        public FundModeViewModels fundModes { get; set; }
        public FundModeViewModels fundNames { get; set; }
    }

}
