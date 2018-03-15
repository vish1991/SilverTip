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
    public class FundModeService : EntityService<FundMode>, IFundModeService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFundModeRepository _fundModeRepository;

        #endregion Member Variables

        #region Constructor

        public FundModeService(IUnitOfWork unitOfWork, IFundModeRepository fundModeRepository)
            : base(unitOfWork, fundModeRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _fundModeRepository = fundModeRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Routes List
        public IEnumerable<FundMode> GetFundModes()
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

        #region Get Fund Modes By Fund Id
        public IEnumerable<FundMode> GetFundModeById(int id)
        {
            try
            {
                return base.GetAll(o => o.Id == id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
