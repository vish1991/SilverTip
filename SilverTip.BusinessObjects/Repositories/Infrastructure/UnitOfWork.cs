using System;
using System.Data.Entity;
using SilverTip.BusinessEntities;

namespace SilverTip.BusinessObjects
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private SilverTipEntities _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public SilverTipEntities DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CommitAsync()
        {
            try
            {
                DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }        
    }
}
