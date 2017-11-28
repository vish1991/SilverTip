using SilverTip.BusinessEntities;
using System;

namespace SilverTip.BusinessObjects
{
    public class DbFactory : Disposable, IDisposable, IDbFactory
    {
        private SilverTipEntities _dbContext;
        public SilverTipEntities Init()
        {
            return _dbContext ?? (_dbContext = new SilverTipEntities());
        }
        public override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
