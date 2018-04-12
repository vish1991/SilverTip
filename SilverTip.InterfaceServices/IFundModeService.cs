﻿using Boughtleaf.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.InterfaceServices
{
    public interface IFundModeService : IEntityService<FundMode>
    {
        IEnumerable<FundMode> GetFundModes();

        FundMode GetFundModeById(int id);
    }
}
