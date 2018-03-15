using Boughtleaf.BusinessEntities;
using SilverTip.BusinessObjects.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class BankRepository : RepositoryBase<Bank>, IBankRepository
    {
        public BankRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
