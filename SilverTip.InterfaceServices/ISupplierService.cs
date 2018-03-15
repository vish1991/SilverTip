using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boughtleaf.BusinessEntities;

namespace SilverTip.InterfaceServices
{
    public interface ISupplierService:IEntityService<Supplier>
    {
        void Add(Supplier entity, out string errorMessege);
        IEnumerable<Supplier> GetAllSupplier();
        void UpdateSupplierDetails(Supplier entity, List<string> properties, bool isIncluded, out string errorMessege);
    }
}
