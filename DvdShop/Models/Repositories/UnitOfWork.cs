using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DvdDbContext _dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        //public DvdDbContext DataContext => _dbContext ?? (_dbContext = _dbFactory.GetDbContext());

        public void Commit()
        {
            _dbContext = _dbFactory.GetDbContext();
            _dbContext.SaveChanges();
        }
    }
}