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
    public class SupplierPaymentTypeController : ApiController
    {
        private readonly ISupplierPaymentTypeService _supplierPaymentType;
        //private readonly IUtilityService _utilityService;
        private readonly IEventLogService _eventLogService;

        public SupplierPaymentTypeController(ISupplierPaymentTypeService supplierPaymentType, IEventLogService eventLogService)
        {
            _supplierPaymentType = supplierPaymentType;
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public IHttpActionResult GetSupplierPaymentTypes()
        {
            try
            {
                IList<SupplierPaymentTypeViewModels> supplierPaymentTypeList = new List<SupplierPaymentTypeViewModels>();
                IEnumerable<SupplierPaymentType> supplierPaymentTypelst;

                supplierPaymentTypelst = _supplierPaymentType.GetSupplierPaymentTypes();

                foreach (SupplierPaymentType supplierPaymentType in supplierPaymentTypelst)
                {
                    SupplierPaymentTypeViewModels supplierPaymentTypeVM = new SupplierPaymentTypeViewModels();

                    supplierPaymentTypeVM.accountName = supplierPaymentType.AccountName;
                    supplierPaymentTypeVM.accountNumber = supplierPaymentType.AccountNumber;
                    supplierPaymentTypeVM.bank = supplierPaymentType.Bank;
                    supplierPaymentTypeVM.bankId = supplierPaymentType.BankId;
                    supplierPaymentTypeVM.branch = supplierPaymentType.Branch;
                    supplierPaymentTypeVM.id = supplierPaymentType.Id;

                    supplierPaymentTypeList.Add(supplierPaymentTypeVM);
                }
                var messageData = new { code = ReadOnlyValue.SuccessMessageCode, message = ReadOnlyValue.MessageSuccess };
                var returnObject = new { supplierPaymentTypeList = supplierPaymentTypeList, messageCode = messageData };
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
        public IHttpActionResult UpdateSupplierPaymentDetails(SupplierPaymentTypeViewModels supplierPaymentType)
        {
            try
            {
                string errorMessege = string.Empty;
                if (ModelState.IsValid)
                {
                    SupplierPaymentType entity = new SupplierPaymentType();
                    entity.AccountName = supplierPaymentType.accountName;
                    entity.AccountNumber = supplierPaymentType.accountNumber;
                    entity.Bank.Name = supplierPaymentType.bankName;
                    entity.BankId = supplierPaymentType.bankId;
                    entity.Branch = supplierPaymentType.branch;
                    entity.Id = supplierPaymentType.id;
                    entity.IsActive = supplierPaymentType.isActive;
                    entity.PayementType = supplierPaymentType.payementType;
                    entity.PaymentTypeId = supplierPaymentType.paymentTypeId;
                    entity.Supplier = supplierPaymentType.supplier;
                    entity.SupplierId = supplierPaymentType.supplierId;

                    List<string> properties = new List<string>();
                    properties.Add("AccountName");
                    properties.Add("AccountNumber");
                    properties.Add("Bank.Name");
                    properties.Add("Branch");

                    _supplierPaymentType.UpdateSupplierPaymentDetails(entity, properties, true, out errorMessege);
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
    }

}
