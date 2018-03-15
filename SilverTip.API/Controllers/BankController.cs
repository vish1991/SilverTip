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
    public class BankController : ApiController
    {
        private readonly IBankService _bank;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public BankController(IBankService bank, IEventLogService eventLogService)
        {
            _bank = bank;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllBanks()
        {
            try
            {
                IList<BankViewModels> bankList = new List<BankViewModels>();
                IEnumerable<Bank> banklst;

                banklst = _bank.GetAllBanks();

                foreach (Bank bank in banklst)
                {
                    BankViewModels bankVM = new BankViewModels();

                    bankVM.id = bank.Id;
                    bankVM.name = bank.Name;
                    bankVM.code = bank.Code;

                    bankList.Add(bankVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { bankList = bankList, messageCode = messageData };
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
