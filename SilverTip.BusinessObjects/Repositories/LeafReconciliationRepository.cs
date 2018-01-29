using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class LeafReconciliationRepository : RepositoryBase<LeafReconciliation>, ILeafReconciliationRepository
    {
        public LeafReconciliationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}