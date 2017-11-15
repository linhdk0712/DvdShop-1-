using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models
{
    public interface IStockRepository:IRepository<Stock>
    {
        
    }
    public class StockRepository:RepositoryBase<Stock>,IStockRepository
    {
        protected StockRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}