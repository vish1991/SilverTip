using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boughtleaf.BusinessEntities;

namespace SilverTip.InterfaceServices
{
    public interface IRouteService:IEntityService<Route>
    {
        IEnumerable<Route> GetRoutes();
    }
}
