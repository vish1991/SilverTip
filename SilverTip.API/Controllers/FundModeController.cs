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
    public class FundModeController : ApiController
    {
        private readonly IFundModeService _fundMode;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public FundModeController(IFundModeService fundMode, IEventLogService eventLogService)
        {
            _fundMode = fundMode;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllFundModes()
        {
            try
            {
                IList<FundModeViewModels> fundModeList = new List<FundModeViewModels>();
                IEnumerable<FundMode> fundModelst;

                fundModelst = _fundMode.GetFundModes();

                foreach (FundMode fundMode in fundModelst)
                {
                    FundModeViewModels fundModeVM = new FundModeViewModels();

                    fundModeVM.id = fundMode.Id;
                    fundModeVM.isActive = fundMode.IsActive;
                    fundModeVM.name = fundMode.Name;
                    fundModeVM.code = fundMode.Code;

                    fundModeList.Add(fundModeVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { fundModeList = fundModeList, messageCode = messageData };
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
