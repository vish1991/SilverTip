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
    public class SupplierTypeController : ApiController
    {
        private readonly ISupplierTypeService _supplierType;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public SupplierTypeController(ISupplierTypeService supplierType, IEventLogService eventLogService)
        {
            _supplierType = supplierType;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllSupplierTypes()
        {
            try
            {
                IList<SupplierTypeViewModels> suppplierTypeList = new List<SupplierTypeViewModels>();
                IEnumerable<SupplierType> supplierTypelst;

                supplierTypelst = _supplierType.GetSupplierType();

                foreach (var supplierType in supplierTypelst)
                {
                    SupplierTypeViewModels supplierTypeVM = new SupplierTypeViewModels();
                    supplierTypeVM.id = supplierType.Id;
                    supplierTypeVM.isActive = supplierType.IsActive;
                    supplierTypeVM.name = supplierType.Name;
                    supplierTypeVM.code = supplierType.Code;

                    suppplierTypeList.Add(supplierTypeVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { suppplierTypeList = suppplierTypeList, messageCode = messageData };
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
