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
    public class CollectionOfficerRouteService : EntityService<CollectionOfficerRoute>, ICollectionOfficerRouteService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICollectionOfficerRouteRepository _collectionOfficerRouteRepository;

        #endregion Member Variables

        #region Constructor

        public CollectionOfficerRouteService(IUnitOfWork unitOfWork, ICollectionOfficerRouteRepository collectionOfficerRouteRepository)
            : base(unitOfWork, collectionOfficerRouteRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _collectionOfficerRouteRepository = collectionOfficerRouteRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Routes List
        public IEnumerable<CollectionOfficerRoute> GetCollectionOfficerRoutes()
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

    }
}
