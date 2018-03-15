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
    public class RouteController : ApiController
    {
        private readonly IRouteService _route;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public RouteController(IRouteService route, IEventLogService eventLogService)
        {
            _route = route;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllRoutes()
        {
            try
            {
                IList<RouteViewModels> routeList = new List<RouteViewModels>();
                IEnumerable<Route> routelst;

                routelst = _route.GetRoutes();

                foreach (Route route in routelst)
                {
                    RouteViewModels routeVM = new RouteViewModels();

                    routeVM.id = route.Id;
                    routeVM.isActive = route.IsActive;
                    routeVM.name = route.Name;
                    routeVM.code = route.Code;

                    routeList.Add(routeVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { routeList = routeList, messageCode = messageData };
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
