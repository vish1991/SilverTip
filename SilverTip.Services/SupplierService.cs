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
    public class SupplierService: EntityService<Supplier>, ISupplierService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;

        #endregion Member Variables

        #region Constructor

        public SupplierService(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository)
            :base(unitOfWork, supplierRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _supplierRepository = supplierRepository;
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

    }
}
