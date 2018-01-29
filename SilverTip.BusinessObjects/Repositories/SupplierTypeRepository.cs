using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class SupplierTypeRepository : RepositoryBase<SupplierType>, ISupplierTypeRepository
    {
        public SupplierTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}