using Boughtleaf.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.InterfaceServices
{
    public interface ISupplierFundService : IEntityService<SupplierFund>
    {
        IEnumerable<SupplierFund> GetSupplierFunds();
        SupplierFund GetSupplierFunds(int supplierId);
    }
}
