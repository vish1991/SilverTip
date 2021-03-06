﻿using Boughtleaf.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.InterfaceServices
{
    public interface IFundService : IEntityService<Fund>
    {
        IEnumerable<Fund> GetFunds();

        Fund GetFundById(int supplierFundId);
    }
}
