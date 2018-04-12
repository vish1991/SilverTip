using Boughtleaf.BusinessEntities;
using SilverTip.BusinessObjects;
using SilverTip.BusinessObjects.Repositories;
using SilverTip.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Services
{
    public class SupplierFundService : EntityService<SupplierFund>, ISupplierFundService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierFundsRepository _supplierFundRepository;

        #endregion Member Variables

        #region Constructor

        public SupplierFundService(IUnitOfWork unitOfWork, ISupplierFundsRepository supplierFundRepository)
            : base(unitOfWork, supplierFundRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _supplierFundRepository = supplierFundRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Routes List
        public IEnumerable<SupplierFund> GetSupplierFunds()
        {
            try
            {
                return base.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region
        public SupplierFund GetSupplierFunds(int supplierId)
        {
            try
            {
                return base.GetAll(x => x.Supplier.Id == supplierId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
