using Boughtleaf.BusinessEntities;
using SilverTip.BusinessObjects;
using SilverTip.BusinessObjects.Repositories;
using SilverTip.BusinessObjects.Repositories.Interface;
using SilverTip.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Services
{
    public class BankService : EntityService<Bank>, IBankService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankRepository _bankRepository;

        #endregion Member Variables

        #region Constructor

        public BankService(IUnitOfWork unitOfWork, IBankRepository bankRepository)
            : base(unitOfWork, bankRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _bankRepository = bankRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Banks List
        public IEnumerable<Bank> GetAllBanks()
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
