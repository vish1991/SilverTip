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
    public class FundService : EntityService<Fund>, IFundService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFundRepository _fundRepository;

        #endregion Member Variables

        #region Constructor

        public FundService(IUnitOfWork unitOfWork, IFundRepository fundRepository)
            : base(unitOfWork, fundRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _fundRepository = fundRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Routes List
        public IEnumerable<Fund> GetFunds()
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

    }
}
