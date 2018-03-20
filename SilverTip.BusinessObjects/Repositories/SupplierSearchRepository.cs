using SilverTip.BusinessEntities;
using SilverTip.BusinessObjects.Repositories.Interface;
using SilverTip.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class SupplierSearchRepository : RepositoryBase<SupplierGridViewModel>, ISupplierSearchRepository
    {
        public SupplierSearchRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
