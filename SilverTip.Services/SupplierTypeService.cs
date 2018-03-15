using SilverTip.BusinessEntities;
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
    public class SupplierTypeService : EntityService<SupplierType>, ISupplierTypeService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierTypeRepository _supplierTypeRepository;

        #endregion Member Variables

        #region Constructor

        public SupplierTypeService(IUnitOfWork unitOfWork, ISupplierTypeRepository supplierTypeRepository)
            : base(unitOfWork, supplierTypeRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _supplierTypeRepository = supplierTypeRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Supplier Type List
        public IEnumerable<SupplierType> GetSupplierType()
        {
            try
            {
                return base.GetAll(o => o.IsActive == true).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
