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
    public class LeafTypeService : EntityService<LeafType>, ILeafTypeService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILeafTypeRepository _leafTypeRepository;

        #endregion Member Variables

        #region Constructor

        public LeafTypeService(IUnitOfWork unitOfWork, ILeafTypeRepository leafTypeRepository)
            : base(unitOfWork, leafTypeRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _leafTypeRepository = leafTypeRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Leaf Type List
        public IEnumerable<LeafType> GetAllLeafTypes()
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
