using Boughtleaf.BusinessEntities;
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
    public class FundController : ApiController
    {
        private readonly IFundService _fund;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public FundController(IFundService fund, IEventLogService eventLogService)
        {
            _fund = fund;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllFunds()
        {
            try
            {
                IList<FundViewModels> fundList = new List<FundViewModels>();
                IEnumerable<Fund> fundlst;

                fundlst = _fund.GetFunds();

                foreach (Fund fund in fundlst)
                {
                    FundViewModels fundVM = new FundViewModels();

                    fundVM.accountNumber = fund.AccountNumber;
                    fundVM.bank = fund.Bank;
                    fundVM.bankId = fund.BankId;
                    fundVM.branch = fund.Branch;
                    fundVM.code = fund.Code;
                    fundVM.description = fund.Description;
                    fundVM.name = fund.Name;
                    fundVM.id = fund.Id;

                    fundList.Add(fundVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { fundList = fundList, messageCode = messageData };
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
