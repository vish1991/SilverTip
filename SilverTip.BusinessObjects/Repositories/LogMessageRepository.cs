using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessObjects.Repositories
{
    public class LogMessageRepository : RepositoryBase<LogMessage>, ILogMessageRepository
    {
        public LogMessageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
