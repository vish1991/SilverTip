using SilverTip.BusinessEntities;
using System;

namespace SilverTip.BusinessObjects
{
    public interface IDbFactory : IDisposable
    {
        SilverTipEntities Init();
    }
}
