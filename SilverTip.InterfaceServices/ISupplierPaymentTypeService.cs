using Boughtleaf.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.InterfaceServices
{
    public interface ISupplierPaymentTypeService : IEntityService<SupplierPaymentType>
    {
        IEnumerable<SupplierPaymentType> GetSupplierPaymentTypes();

        void UpdateSupplierPaymentDetails(SupplierPaymentType entity, List<string> properties, bool isIncluded, out string errorMessege);
    }
}
