using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Repositories
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DvdDbContext _dbContext;
        public DvdDbContext GetDbContext()
        {
            return _dbContext ?? (_dbContext = new DvdDbContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}