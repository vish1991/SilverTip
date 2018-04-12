using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using SilverTip.Common;
using SilverTip.Common.ViewModels;
using SilverTip.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace SilverTip.API.Controllers
{
    public class SupplierFundController : ApiController
    {
        private readonly ISupplierFundService _supplierFund;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;
        private readonly IFundService _fund;
        private readonly ISupplierService _supplier;
        private readonly IFundModeService _fundMode;

        public SupplierFundController(ISupplierFundService supplierFund, IEventLogService eventLogService, IFundService fund, ISupplierService supplier, IFundModeService fundMode)
        {
            _supplierFund = supplierFund;
            _eventLogService = eventLogService;
            _fund = fund;
            _supplier = supplier;
            _fundMode = fundMode;
        }



        [HttpGet]
        public IHttpActionResult GetAllFundsById(int id)
        {
            try
            {
                SupplierFundViewModels supplierFundDetailsVM = new SupplierFundViewModels();

                SupplierFund supplierFund = new SupplierFund();
                supplierFund = _supplierFund.GetSupplierFunds(id);

                Supplier supplier = new Supplier();
                Fund fund = new Fund();
                FundMode fundMode = new FundMode();

                supplierFundDetailsVM.supplierFunds = new List<SupplierFundUpdateViewModel>();
                if (supplierFund != null)
                {
                    SupplierFundUpdateViewModel supplierFundList = new SupplierFundUpdateViewModel();
                    supplier = _supplier.GetSupplier(supplierFund.SupplierId);
                    fund = _fund.GetFundById(supplierFund.FundId);
                    fundMode = _fundMode.GetFundModeById(supplierFund.FundModeId);

                    supplierFundDetailsVM.supplierId = supplier.Id;

                    supplierFundList.fundModes = new FundModeViewModels();
                    supplierFundList.fundModes.id = fundMode.Id;
                    supplierFundList.fundModes.name = fundMode.Name;

                    supplierFundList.fundAmount = supplierFund.Amount;

                    supplierFundList.fundNames = new FundModeViewModels();
                    supplierFundList.fundNames.id = fundMode.Id;
                    supplierFundList.fundNames.name = fund.Name;

                    //supplierFundDetailsVM.supplier.id = supplierFund.SupplierId;
                    //supplierFundDetailsVM.amount = supplierFund.Amount;
                    //supplierFundDetailsVM.fundModes.id = supplierFund.FundModeId;
                    //supplierFundDetailsVM.fundModes.name = supplierFund.FundMode.Name;
                    //supplierFundDetailsVM.funds = new FundViewModel();
                    //supplierFundDetailsVM.funds.id = _fund.GetFunds().Where(x=>x.Id == supplierFund.FundId).FirstOrDefault().Id;
                    //supplierFundDetailsVM.funds.name = supplierFund.Fund.Name;
                    supplierFundDetailsVM.supplierFunds.Add(supplierFundList);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { supplierFundDetailsVM = supplierFundDetailsVM, messageCode = messageData };
                return Ok(returnObject);
            }
            catch(Exception ex)
            {
                string errorLogId = _eventLogService.WriteLogs(User.Identity.Name, ex, MethodBase.GetCurrentMethod().Name);
                var messageData = new { code = ReadOnlyValue.ErrorMessageCode, message = String.Format(ReadOnlyValue.MessageTaskmateError, errorLogId) };
                var returnObject = new { messageCode = messageData };
                return Ok(returnObject);
            }
        }


        [HttpGet]
        public IHttpActionResult GetAllFunds()
        {
            try
            {
                IList<SupplierFundViewModels> supplierFundList = new List<SupplierFundViewModels>();
                IEnumerable<SupplierFund> supplierFundlst;

                supplierFundlst = _supplierFund.GetSupplierFunds();

                foreach (SupplierFund supplierFund in supplierFundlst)
                {
                    SupplierFundViewModels fundVM = new SupplierFundViewModels();
                    fundVM.supplier.id = supplierFund.Supplier.Id;
                    fundVM.fundId = supplierFund.FundId;
                    fundVM.fundModeId = supplierFund.FundModeId;
                    fundVM.fundAmount = supplierFund.Amount;
                    fundVM.fundModes.name = supplierFund.FundMode.Name;
                    fundVM.fundNames.name = supplierFund.Fund.Name;

                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { supplierFundList = supplierFundList, messageCode = messageData };
                return Ok(returnObject);
            }

            catch (Exception ex)
            {
                string errorLogId = _eventLogService.WriteLogs(User.Identity.Name, ex, MethodBase.GetCurrentMethod().Name);
                var messageData = new { code = ReadOnlyValue.ErrorMessageCode, message = String.Format(ReadOnlyValue.MessageTaskmateError, errorLogId) };
                var returnObject = new { messageCode = messageData };
                return Ok(returnObject);
            }
        }
    }
}
