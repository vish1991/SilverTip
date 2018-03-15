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
    public class LeafTypeController : ApiController
    {
        private readonly ILeafTypeService _leafType;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public LeafTypeController(ILeafTypeService leafType, IEventLogService eventLogService)
        {
            _leafType = leafType;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllLeafTypes()
        {
            try
            {
                IList<LeafTypeViewModels> leafTypeList = new List<LeafTypeViewModels>();
                IEnumerable<LeafType> leafTypelst;

                leafTypelst = _leafType.GetAllLeafTypes();

                foreach (LeafType leafType in leafTypelst)
                {
                    LeafTypeViewModels leafTypeVM = new LeafTypeViewModels();

                    leafTypeVM.id = leafType.Id;
                    leafTypeVM.isActive = leafType.IsActive;
                    leafTypeVM.name = leafType.Name;
                    leafTypeVM.code = leafType.Code;

                    leafTypeList.Add(leafTypeVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { leafTypeList = leafTypeList, messageCode = messageData };
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
