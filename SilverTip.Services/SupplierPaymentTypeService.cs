using SilverTip.BusinessEntities;
using SilverTip.BusinessObjects;
using SilverTip.BusinessObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boughtleaf.BusinessEntities;
using SilverTip.InterfaceServices;

namespace SilverTip.Services
{
    public class SupplierPaymentTypeService : EntityService<SupplierPaymentType>, ISupplierPaymentTypeService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierPaymentTypeRepository _supplierPaymentTypeRepository;

        #endregion Member Variables

        #region Constructor

        public SupplierPaymentTypeService(IUnitOfWork unitOfWork,ISupplierPaymentTypeRepository supplierPaymentTypeRepository)
            : base(unitOfWork, supplierPaymentTypeRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _supplierPaymentTypeRepository = supplierPaymentTypeRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Supplier Payment Type List
        public IEnumerable<SupplierPaymentType> GetSupplierPaymentTypes()
        {
            try
            {
                return base.GetAll(o => o.IsActive == true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Update Supplier Payment Type Details
        public virtual void UpdateSupplierPaymentDetails(SupplierPaymentType entity, List<string> properties, bool isIncluded, out string errorMessege)
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

    }
}
