using Boughtleaf.BusinessEntities;
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
        public IHttpActionResult CreateSupplier(SupplierFormViewModel supplier)
        {
            try
            {
                string errorMessege = string.Empty;
                if (ModelState.IsValid)
                {
                    Supplier entity = new Supplier();
                    entity.Address = supplier.address;
                    entity.ContactNo = supplier.contactNumber;
                    entity.FullName = supplier.fullName;
                    entity.IsActive = supplier.isActive;
                    entity.LeafTypeId = supplier.leafTypes.id;
                    entity.NICNo = supplier.nicNo;
                    entity.Notes = supplier.notes;
                    entity.RegNo = supplier.registrationNo;
                    entity.RouteId = supplier.routes.id;
                    entity.SupplierTypeId = supplier.types.id;
                    entity.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                    entity.CreatedBy = "admin";//User.Identity.Name;
                    entity.ModifiedBy = "admin";
                    entity.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                                        
                    SupplierPaymentType supplierPaymentType = new SupplierPaymentType();
                    supplierPaymentType.SupplierId = entity.Id;
                    supplierPaymentType.PaymentTypeId = supplier.supplierPaymentTypes.paymentModes.id;
                    supplierPaymentType.AccountName = supplier.supplierPaymentTypes.accountName;
                    supplierPaymentType.AccountNumber = supplier.supplierPaymentTypes.accountNumber;
                    supplierPaymentType.BankId = supplier.supplierPaymentTypes.banks.id;
                    supplierPaymentType.Branch = supplier.supplierPaymentTypes.branch;
                    entity.SupplierPaymentTypes.Add(supplierPaymentType);

                    foreach (SupplierFundViewModel fundsVm in supplier.SupplierFunds)
                    {
                        SupplierFund supplierFund = new SupplierFund();

                        supplierFund.SupplierId = entity.Id;

                        supplierFund.Amount = fundsVm.fundAmount;
                        supplierFund.FundId = fundsVm.fundNames.id;
                        supplierFund.FundModeId = fundsVm.fundModes.id;
                        supplierFund.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                        supplierFund.CreatedBy = "admin";//User.Identity.Name;
                        supplierFund.ModifiedBy = "admin";
                        supplierFund.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));


                        entity.SupplierFunds.Add(supplierFund);
                    }


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
                return Ok();
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllSupplier()
        {
            try
            {
                IList<SupplierFormViewModel> supplierList = new List<SupplierFormViewModel>();
                IEnumerable<Supplier> lstSupplier;

                lstSupplier = _supplier.GetAllSupplier();

                foreach (Supplier supplier in lstSupplier)
                {
                    SupplierFormViewModel supplierVM = new SupplierFormViewModel();

                    supplierVM.id = supplier.Id;
                    supplierVM.registrationNo = supplier.RegNo;
                    supplierVM.types.id = supplier.SupplierType.Id;
                    supplierVM.isActive = supplier.IsActive;
                    supplierVM.fullName = supplier.FullName;
                    supplierVM.address = supplier.Address;
                    supplierVM.routes.id = supplier.RouteId;
                    supplierVM.types.id = supplier.SupplierTypeId;

                    supplierList.Add(supplierVM);
                }

                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { supplierList = supplierList, messageCode = messageData };
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

        //[HttpPost]
        //public IHttpActionResult UpdateSupplierDetails(SupplierFormViewModel supplier)
        //{
        //    try
        //    {
        //        string errorMessege = string.Empty;
        //        if (ModelState.IsValid)
        //        {
        //            Supplier entity = new Supplier();
        //            entity.RegNo = supplier.regNo;
        //            entity.FullName = supplier.fullName;
        //            entity.Address = supplier.address;
        //            entity.ContactNo = supplier.contactNo;
        //            entity.Route.Name = supplier.routeName;
        //            entity.SupplierType.Name = supplier.supplierTypeName;
        //            entity.NICNo = supplier.nicNo;
        //            entity.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
        //            entity.CreatedBy = "admin";//User.Identity.Name;
        //            entity.ModifiedBy = "admin";
        //            entity.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"])); ;

        //            List<string> properties = new List<string>();
        //            properties.Add("RegNo");
        //            properties.Add("FullName");
        //            properties.Add("Address");
        //            properties.Add("ContactNo");
        //            properties.Add("Route.Name");
        //            properties.Add("SupplierType.Name");
        //            properties.Add("NICNo");

        //            _supplier.UpdateSupplierDetails(entity, properties, true, out errorMessege);
        //        }
        //        else
        //        {
        //            errorMessege = ReadOnlyValue.GeneralError;
        //        }
        //        var messageData = new
        //        {
        //            code = String.IsNullOrEmpty(errorMessege) ? ReadOnlyValue.SuccessMessageCode : ReadOnlyValue.ErrorMessageCode,
        //            message = String.IsNullOrEmpty(errorMessege) ? ReadOnlyValue.MessageSuccess : errorMessege
        //        };
        //        var returnObject = new { messageCode = messageData };
        //        return Ok(returnObject);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorLogId = _eventLogService.WriteLogs(User.Identity.Name, ex, MethodBase.GetCurrentMethod().Name);
        //        var messageData = new { code = ReadOnlyValue.ErrorMessageCode, message = String.Format(ReadOnlyValue.MessageTaskmateError, errorLogId) };
        //        var returnObject = new { messageCode = messageData };
        //        return Ok(returnObject);
        //    }
        //}
    }
}
