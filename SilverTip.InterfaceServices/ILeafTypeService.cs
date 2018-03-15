using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.InterfaceServices
{
    public interface ILeafTypeService : IEntityService<LeafType>
    {
        IEnumerable<LeafType> GetAllLeafTypes();
    }
}
