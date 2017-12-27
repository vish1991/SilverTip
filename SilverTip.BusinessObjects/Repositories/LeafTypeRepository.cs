using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class LeafTypeRepository : RepositoryBase<LeafType>, LeafTypesRepository
    {
        public LeafTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}