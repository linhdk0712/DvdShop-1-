using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models
{
    public interface IIngredientsRepository : IRepository<Ingredients>
    {
        
    }
    public class IngredientsRepository : RepositoryBase<Ingredients>,IIngredientsRepository
    {
        protected IngredientsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}