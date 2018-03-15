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
    public class CollectionOfficerController : ApiController
    {
        private readonly ICollectionOfficerService _collectionOfficer;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public CollectionOfficerController(ICollectionOfficerService collectionOfficer, IEventLogService eventLogService)
        {
            _collectionOfficer = collectionOfficer;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetAllCollectionOfficers()
        {
            try
            {
                IList<CollectionOfficerViewModels> collectionOfficerList = new List<CollectionOfficerViewModels>();
                IEnumerable<CollectionOfficer> collectionOfficerlst;

                collectionOfficerlst = _collectionOfficer.GetCollectionOfficers();

                foreach (CollectionOfficer collectionOfficer in collectionOfficerlst)
                {
                    CollectionOfficerViewModels collectionOfficerVM = new CollectionOfficerViewModels();

                    collectionOfficerVM.id = collectionOfficer.Id;
                    collectionOfficerVM.isActive = collectionOfficer.IsActive;
                    collectionOfficerVM.name = collectionOfficer.Name;
                    collectionOfficerVM.address = collectionOfficer.Address;
                    collectionOfficerVM.contactNo = collectionOfficer.ContactNo;

                    collectionOfficerList.Add(collectionOfficerVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { collectionOfficerList = collectionOfficerList, messageCode = messageData };
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
