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

namespace SilverTip.Services
{
    public class SupplierService : EntityService<Supplier>, ISupplierService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierSearchRepository _supplierSearchRepository;
        #endregion Member Variables

        #region Constructor

        public SupplierService(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, ISupplierSearchRepository supplierSearchRepository)
            : base(unitOfWork, supplierRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _supplierRepository = supplierRepository;
                _supplierSearchRepository = supplierSearchRepository;
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
        public virtual void UpdateSupplierDetails(Supplier entity, List<string> properties, bool isIncluded, out string errorMessege)
        {
            try
            {
                base.Update(entity, properties, isIncluded);
                errorMessege = String.Empty;
            }
            catch (Exception ex)
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