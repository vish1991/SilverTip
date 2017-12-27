using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class CollectionOfficerRouteRepository : RepositoryBase<CollectionOfficerRoute>, ICollectionOfficerRoutesRepository
    {
        public CollectionOfficerRouteRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
