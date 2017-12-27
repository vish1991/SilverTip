using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class CollectionOfficerRepository : RepositoryBase<CollectionOfficer>, ICollectionOfficersRepository
    {
        public CollectionOfficerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}