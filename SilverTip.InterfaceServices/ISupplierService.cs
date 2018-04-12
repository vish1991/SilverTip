using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boughtleaf.BusinessEntities;
using SilverTip.Common.ViewModels;

namespace SilverTip.InterfaceServices
{
    public interface ISupplierService:IEntityService<Supplier>
    {
        void Add(Supplier entity, out string errorMessege);
        IEnumerable<Supplier> GetAllSupplier();
        void UpdateSupplierDetails(UpdateSupplierPersonalDetailsViewModel entity, List<string> properties, bool isIncluded, out string errorMessege);
        IEnumerable<SupplierGridViewModel> SearchSupplier(int pageSize, int pageNum, string registrationNo, string fullName, int routeId, int typeId, bool isActive, string sortColumn, string sortOrder);
        Supplier GetSupplier(int supplierId);
        void UpdateSupplierFinanceDetails(UpdateSupplierFinancialDetailsViewModel entity, List<string> properties, bool isIncluded, out string errorMessege);
    }
}
