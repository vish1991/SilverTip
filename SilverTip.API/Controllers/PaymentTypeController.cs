using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using SilverTip.Common;
using SilverTip.Common.ViewModels;
using SilverTip.InterfaceServices;
using SilverTip.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace SilverTip.API.Controllers
{
    public class PaymentTypeController : ApiController
    {
        private readonly IPaymentTypeService _paymentType;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public PaymentTypeController(IPaymentTypeService paymentType, IEventLogService eventLogService)
        {
            _paymentType = paymentType;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllPaymentTypes()
        {
            try
            {

                IList<PaymentTypeViewModels> paymentTypeList = new List<PaymentTypeViewModels>();
                IEnumerable<PaymentType> lstPaymentType;

                lstPaymentType = _paymentType.GetPaymentTypes();

                foreach (var paymentType in lstPaymentType)
                {
                    PaymentTypeViewModels paymentTypeVM = new PaymentTypeViewModels();
                    paymentTypeVM.id = paymentType.Id;
                    paymentTypeVM.isActive = paymentType.IsActive;
                    paymentTypeVM.name = paymentType.Name;
                    paymentTypeVM.code = paymentType.Code;

                    paymentTypeList.Add(paymentTypeVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { paymentTypeList = paymentTypeList, messageCode = messageData };
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
    }
}
