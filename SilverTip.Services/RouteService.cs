using SilverTip.BusinessEntities;
using SilverTip.BusinessObjects;
using SilverTip.BusinessObjects.Repositories;
using SilverTip.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boughtleaf.BusinessEntities;

namespace SilverTip.Services
{
    public class RouteService : EntityService<Route>, IRouteService
    {
        #region Member Variables

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRouteRepository _routeRepository;

        #endregion Member Variables

        #region Constructor

        public RouteService(IUnitOfWork unitOfWork, IRouteRepository routeRepository)
            : base(unitOfWork, routeRepository)
        {
            try
            {
                _unitOfWork = unitOfWork;
                _routeRepository = routeRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Constructor

        #region Get Routes List
        public IEnumerable<Route> GetRoutes()
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
