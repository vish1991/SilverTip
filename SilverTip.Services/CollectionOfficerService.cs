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
    public class CollectionOfficerService : EntityService<CollectionOfficer>, ICollectionOfficerService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICollectionOfficerRepository _collectionOfficerRepository;

        #endregion Member Variables

        #region Constructor

        public CollectionOfficerService(IUnitOfWork unitOfWork, ICollectionOfficerRepository collectionOfficerRepository)
            : base(unitOfWork, collectionOfficerRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _collectionOfficerRepository = collectionOfficerRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Collection Officer List
        public IEnumerable<CollectionOfficer> GetCollectionOfficers()
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
