using Boughtleaf.BusinessEntities;
using Microsoft.AspNet.Identity;
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
        public IHttpActionResult CreateSuppliers(SupplierFormViewModel supplier)
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

                    foreach (SupplierFundViewModel fundsVm in supplier.supplierFunds)
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


        [HttpPost]
        public IHttpActionResult SearchSupplierGrid(SupplierGridSearchCriteriaViewModel searchData)
        {
            try
            {
                IList<SupplierGridData> suppliersList = new List<SupplierGridData>();
                IEnumerable<SupplierGridViewModel> supplierDataList = new List<SupplierGridViewModel>();
                supplierDataList = _supplier.SearchSupplier(searchData.pageSize, searchData.pageNum, searchData.registrationNo, searchData.fullName, searchData.routesId, searchData.typesId, searchData.isActive, searchData.sortColumn, searchData.sortOrder);
                foreach (SupplierGridViewModel supplier in supplierDataList)
                {
                    SupplierGridData supplierViewModel = new SupplierGridData();
                    supplierViewModel.id = supplier.Id;
                    supplierViewModel.registrationNo = supplier.RegNo;
                    supplierViewModel.fullName = supplier.FullName;
                    supplierViewModel.address = supplier.Address;
                    supplierViewModel.contactNumber = supplier.ContactNo;
                    supplierViewModel.nicNo = supplier.NICNo;
                    supplierViewModel.routeID = supplier.sRouteId;
                    supplierViewModel.typeID = supplier.sTypeId;
                    supplierViewModel.routeName = supplier.route;
                    supplierViewModel.typeName = supplier.type;
                    supplierViewModel.isActive = supplier.IsActive;
                    supplierViewModel.totalRows = supplier.totalRows;

                    suppliersList.Add(supplierViewModel);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { suppliersList = suppliersList, messageCode = messageData };
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

        [HttpGet]
        public IHttpActionResult GetSupplierDetails(int id)
        {
            try
            {
                //UpdateSupplierDetailsViewModel updateSupplierDetailsViewModel = new UpdateSupplierDetailsViewModel();
                SupplierFormViewModel updateSupplierDetailsViewModel = new SupplierFormViewModel();
                //SupplierPaymentTypeViewModel supplierPaymentType = new SupplierPaymentTypeViewModel();
                Supplier supplier = new Supplier();
                supplier = _supplier.GetSupplier(id);
                if(supplier != null)
                {
                    updateSupplierDetailsViewModel.supplierPaymentTypes = new SupplierPaymentTypeViewModel();
                    updateSupplierDetailsViewModel.supplierPaymentTypes.accountName = supplier.SupplierPaymentTypes.FirstOrDefault().AccountName;
                    updateSupplierDetailsViewModel.supplierPaymentTypes.accountNumber = supplier.SupplierPaymentTypes.FirstOrDefault().AccountNumber;

                    updateSupplierDetailsViewModel.supplierPaymentTypes.banks = new BankViewModels();
                    updateSupplierDetailsViewModel.supplierPaymentTypes.banks.id = supplier.SupplierPaymentTypes.FirstOrDefault().Bank.Id;
                    updateSupplierDetailsViewModel.supplierPaymentTypes.banks.name = supplier.SupplierPaymentTypes.FirstOrDefault().Bank.Name;

                    updateSupplierDetailsViewModel.supplierPaymentTypes.branch = supplier.SupplierPaymentTypes.FirstOrDefault().Branch;

                    updateSupplierDetailsViewModel.supplierPaymentTypes.paymentModes = new PaymentTypeViewModels();
                    updateSupplierDetailsViewModel.supplierPaymentTypes.paymentModes.name = supplier.SupplierPaymentTypes.FirstOrDefault().PayementType.Name;
                    updateSupplierDetailsViewModel.supplierPaymentTypes.paymentModes.id = supplier.SupplierPaymentTypes.FirstOrDefault().PayementType.Id;
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { updateSupplierDetailsViewModel = updateSupplierDetailsViewModel, messageCode = messageData };
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

        [HttpPost]
        public IHttpActionResult UpdateSupplierFinancialDetails(UpdateSupplierFinancialDetailsViewModel supplier)
        {
            try
            {
                string errorMessege = string.Empty;
                if (ModelState.IsValid)
                {
                    List<string> properties = new List<string>();
                    properties.Add("AccountNumber");
                    properties.Add("AccountName");
                    properties.Add("Branch");
                    properties.Add("BankId");
                    properties.Add("PaymentTypeId");
                    _supplier.UpdateSupplierFinanceDetails(supplier, properties, true, out errorMessege);
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
            catch(Exception ex)
            {
                string errorLogId = _eventLogService.WriteLogs(User.Identity.Name, ex, MethodBase.GetCurrentMethod().Name);
                var messageData = new { code = ReadOnlyValue.ErrorMessageCode, message = String.Format(ReadOnlyValue.MessageTaskmateError, errorLogId) };
                var returnObject = new { messageCode = messageData };
                return Ok(returnObject);
            }
        }



        [HttpPost]
        public IHttpActionResult UpdateSupplierPersonalDetails(UpdateSupplierPersonalDetailsViewModel supplier)
        {
            try
            {
                string errorMessege = string.Empty;
                if (ModelState.IsValid)
                {

                    List<string> properties = new List<string>();
                    properties.Add("RegNo");
                    properties.Add("FullName");
                    properties.Add("Address");
                    properties.Add("ContactNo");
                    properties.Add("NICNo");
                    _supplier.UpdateSupplierDetails(supplier, properties, true, out errorMessege);
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
