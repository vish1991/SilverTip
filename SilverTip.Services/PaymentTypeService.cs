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
    public class PaymentTypeService: EntityService<PaymentType>, IPaymentTypeService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        #endregion Member Variables

        #region Constructor

        public PaymentTypeService(IUnitOfWork unitOfWork, IPaymentTypeRepository paymentTypeRepository)
            : base(unitOfWork, paymentTypeRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _paymentTypeRepository = paymentTypeRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Get All Payment Types
        public IEnumerable<PaymentType> GetPaymentTypes()
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

    }
}
#endregion