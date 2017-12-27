using Boughtleaf.BusinessEntities;
using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, SuppliersRepository
    {
        public SupplierRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}