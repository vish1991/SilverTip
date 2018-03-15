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
    public class CollectionOfficerRouteController : ApiController
    {
        private readonly ICollectionOfficerRouteService _collectionOfficerRoute;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public CollectionOfficerRouteController(ICollectionOfficerRouteService collectionOfficerRoute, IEventLogService eventLogService)
        {
            _collectionOfficerRoute = collectionOfficerRoute;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllCollectionOfficerRoutes()
        {
            try
            {
                IList<CollectionOfficerRouteViewModels> collectionOfficerRouteList = new List<CollectionOfficerRouteViewModels>();
                IEnumerable<CollectionOfficerRoute> collectionOfficerRoutelst;

                collectionOfficerRoutelst = _collectionOfficerRoute.GetCollectionOfficerRoutes();

                foreach (CollectionOfficerRoute collectionOfficerRoute in collectionOfficerRoutelst)
                {
                    CollectionOfficerRouteViewModels collectionOfficerRouteVM = new CollectionOfficerRouteViewModels();

                    collectionOfficerRouteVM.id = collectionOfficerRoute.Id;
                    collectionOfficerRouteVM.route = collectionOfficerRoute.Route;
                    collectionOfficerRouteVM.routeId = collectionOfficerRoute.RouteId;
                    collectionOfficerRouteVM.collectionOfficer = collectionOfficerRoute.CollectionOfficer;
                    collectionOfficerRouteVM.collectionOfficerId = collectionOfficerRoute.CollectionOfficerId;
                    collectionOfficerRouteVM.date = collectionOfficerRoute.Date;

                    collectionOfficerRouteList.Add(collectionOfficerRouteVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { collectionOfficerRouteList = collectionOfficerRouteList, messageCode = messageData };
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
