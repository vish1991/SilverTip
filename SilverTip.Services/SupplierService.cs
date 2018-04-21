using SilverTip.BusinessEntities;
using SilverTip.BusinessObjects;
using SilverTip.BusinessObjects.Repositories;
using SilverTip.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boughtleaf.BusinessEntities;
using System.Data.SqlClient;
using SilverTip.Common.ViewModels;
using System.Configuration;
using SilverTip.BusinessObjects.Repositories.Interface;

namespace SilverTip.Services
{
    public class SupplierService : EntityService<Supplier>, ISupplierService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierSearchRepository _supplierSearchRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly ISupplierTypeRepository _supplierTypeRepository;
        private readonly ISupplierPaymentTypeRepository _supplierPaymentTypeRepository;
        private readonly ISupplierFundsRepository _supplierFundsRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IBankRepository _bankRepository;

        #endregion Member Variables

        #region Constructor

        public SupplierService(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, ISupplierSearchRepository supplierSearchRepository, 
            IRouteRepository routeRepository, ISupplierTypeRepository supplierTypeRepository, ISupplierPaymentTypeRepository supplierPaymentTypeRepository, 
            ISupplierFundsRepository supplierFundsRepository, IPaymentTypeRepository paymentTypeRepository, IBankRepository bankRepository)
            : base(unitOfWork, supplierRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _supplierRepository = supplierRepository;
                _supplierSearchRepository = supplierSearchRepository;
                _routeRepository = routeRepository;
                _supplierTypeRepository = supplierTypeRepository;
                _supplierPaymentTypeRepository = supplierPaymentTypeRepository;
                _supplierFundsRepository = supplierFundsRepository;
                _paymentTypeRepository = paymentTypeRepository;
                _bankRepository = bankRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Constructor

        #region Public Methods
        public virtual void Add(Supplier entity, out string errorMessege)
        {
            try
            {
                StringBuilder sbErrorMessage = new StringBuilder();
                IList<Supplier> existSuppliers = base.GetAll(o => o.RegNo == entity.RegNo && o.IsActive == true).ToList();
                if (existSuppliers != null && existSuppliers.Count > 0)
                {
                    sbErrorMessage.AppendFormat("Reg No : {0} already added to system", entity.RegNo.ToString());
                    errorMessege = sbErrorMessage.ToString();
                }
                else
                {
                    base.Add(entity);
                    errorMessege = string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Get All Supplier
        public IEnumerable<Supplier> GetAllSupplier()
        {
            try
            {
                return base.GetAll(x => x.IsActive == true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update Supplier Details
        public virtual void UpdateSupplierDetails(UpdateSupplierPersonalDetailsViewModel entity, List<string> properties, bool isIncluded, out string errorMessege)
        {
            try
            {
                using (var dbContextTransaction = _supplierRepository.DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Supplier supplier = new Supplier();

                        supplier = _supplierRepository.Get(x => x.RegNo == entity.registrationNo).FirstOrDefault();
                        supplier.RegNo = entity.registrationNo;
                        supplier.FullName = entity.fullName;
                        supplier.Address = entity.address;
                        supplier.ContactNo = entity.contactNumber;
                        supplier.NICNo = entity.nicNo;
                        supplier.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                        supplier.CreatedBy = "admin";//User.Identity.Name;
                        supplier.ModifiedBy = "admin";
                        supplier.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));

                        base.Update(supplier, properties, isIncluded);

                        properties.Clear();
                        properties.Add("Name");

                        Route route = new Route();
                        route = supplier.Route;
                        route.Name = entity.routes.name;
                        _routeRepository.Update(route, properties, true);

                        properties.Clear();
                        properties.Add("Name");
                        SupplierType suppliertype = new SupplierType();
                        suppliertype = supplier.SupplierType;
                        suppliertype.Name = entity.types.name;
                        _supplierTypeRepository.Update(suppliertype, properties, true);
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw ex;
                    }
                }
                
                errorMessege = String.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Update Supplier Financial Details
        public virtual void UpdateSupplierFinanceDetails(UpdateSupplierFinancialDetailsViewModel entity, List<string> properties, bool isIncluded, out string errorMessege)
        {
            try
            {
                using (var dbContextTransaction = _supplierPaymentTypeRepository.DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //Supplier supplier = new Supplier();
                        //supplier = _supplierRepository.Get(x => x.Id == entity.id).FirstOrDefault();

                        SupplierPaymentType supplierPaymentType = new SupplierPaymentType();
                        supplierPaymentType = _supplierPaymentTypeRepository.Get(o => o.SupplierId == entity.id).FirstOrDefault();// supplier.SupplierPaymentTypes.Where(x => x.SupplierId == entity.id).FirstOrDefault();

                        supplierPaymentType.AccountNumber = entity.accountNumber;
                        supplierPaymentType.AccountName = entity.accountName;
                        supplierPaymentType.Branch = entity.branch;
                        supplierPaymentType.BankId = entity.banks.id;
                        supplierPaymentType.PaymentTypeId = entity.paymentModes.id;

                        _supplierPaymentTypeRepository.Update(supplierPaymentType, properties, true);


                        properties.Clear();
                        properties.Add("FundModeId");
                        properties.Add("FundId");
                        properties.Add("Amount");
                        properties.Add("ModifiedDate");
                        properties.Add("ModifiedBy");

                        foreach (SupplierFundViewModel item in entity.supplierFunds)
                        {
                            if (item.supplierFundId != 0) //make this !=0 after sending the supplierFundId from the front end
                            {

                                SupplierFund supplierFund = new SupplierFund();
                                supplierFund = _supplierFundsRepository.Get(x => x.Id == item.supplierFundId).FirstOrDefault(); // 28 should be item.id -- and SupplierFundViewModel's id should be the supplierFundId
                                supplierFund.FundModeId = item.fundModes.id;
                                supplierFund.FundId = item.fundNames.id;
                                supplierFund.Amount = item.fundAmount;
                                supplierFund.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                                supplierFund.CreatedBy = "admin";//User.Identity.Name;
                                supplierFund.ModifiedBy = "admin";
                                supplierFund.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));

                                _supplierFundsRepository.Update(supplierFund, properties, true);
                            }
                            else
                            {

                                SupplierFund supplierFund = new SupplierFund();
                                supplierFund.FundModeId = item.fundModes.id;
                                supplierFund.FundId = item.fundNames.id;
                                supplierFund.Amount = item.fundAmount;
                                supplierFund.SupplierId = entity.id;
                                supplierFund.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));
                                supplierFund.CreatedBy = "admin";//User.Identity.Name;
                                supplierFund.ModifiedBy = "admin";
                                supplierFund.ModifiedDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["LocalTimeZone"]));

                                _supplierFundsRepository.Add(supplierFund);
                            }
                        }
                        errorMessege = String.Empty;
                        _unitOfWork.Commit();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw ex;
                    }
                }
                errorMessege = String.Empty;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }


        #endregion

        #region Search Supplier
        public IEnumerable<SupplierGridViewModel> SearchSupplier(int pageSize, int pageNum, string registrationNo, string fullName, int routeId, int typeId, bool isActive, string sortColumn, string sortOrder)
        {
            try
            {
                string errorMessage = String.Empty;
                object[] param ={
                new SqlParameter("@registrationNo", registrationNo),
                new SqlParameter("@fullName", fullName),
                new SqlParameter("@routeId", routeId),
                new SqlParameter("@typeId", typeId),
                new SqlParameter("@isActive", isActive),
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageNum", pageNum),
                new SqlParameter("@sortColumn", sortColumn),
                new SqlParameter("@sortOrder", sortOrder)
            };
                return _supplierSearchRepository.ExecuteStoredProcedure("dbo.SearchSuppliers @pagesize, @pageNum, @registrationNo, @fullName, @routeId, @typeId, @isActive, @sortColumn, @sortOrder", param);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Supplier GetSupplier(int supplierId)
        {
            try
            {
                return base.GetAll(x => x.Id == supplierId).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        //#region Update Supplier Account Details
        //public void UpdateAccountDetails(Supplier entity, List<string> properties, bool isIncluded, out string errorMessege)
        //{
        //    try
        //    {
        //        base.Update(entity, properties, isIncluded);
        //        errorMessege = String.Empty;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion
    }
}