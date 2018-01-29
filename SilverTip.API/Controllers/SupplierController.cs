using SilverTip.BusinessEntities;
using SilverTip.Common;
using SilverTip.Common.ViewModels;
using SilverTip.InterfaceServices;
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
    public class SupplierController : ApiController
    {
        private readonly ISupplierService _supplier;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public SupplierController(ISupplierService supplier, IEventLogService eventLogService)
        {
            _supplier = supplier;
            _eventLogService = eventLogService;
        }

        [HttpPost]
        public IHttpActionResult Post(SupplierFormViewModel supplier)
        {
            try
            {
                string errorMessege = string.Empty;
                if (ModelState.IsValid)
                {
                    Supplier entity = new Supplier();
                    entity.Address = supplier.address;
                    entity.ContactNo = supplier.contactNo;
                    entity.FullName = supplier.fullName;
                    entity.IsActive = supplier.isActive;
                    entity.LeafTypeId = supplier.leafTypeId;
                    entity.NICNo = supplier.nicNo;
                    entity.Notes = supplier.notes;
                    entity.RegNo = supplier.regNo;
                    entity.RouteId = supplier.routeId;
                    entity.SupplierTypeId = supplier.supplierTypeId;
                    entity.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                    entity.CreatedBy = "admin";//User.Identity.Name;
                    entity.ModifiedBy = "admin";
                    entity.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"])); ;
                   
                    _supplier.Add(entity, out errorMessege);
                }
                else
                {
                    errorMessege = ReadOnlyValue.GeneralError;
                }

                var messageData = new
                {
                    code = String.IsNullOrEmpty(errorMessege) ? ReadOnlyValue.SuccessMessageCode : ReadOnlyValue.ErrorMessageCode,
                    message = String.IsNullOrEmpty(errorMessege) ? ReadOnlyValue.MessageSuccess : errorMessege
                };
                var returnObject = new { messageCode = messageData };
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
