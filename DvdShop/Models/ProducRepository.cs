using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models
{
    public interface IProducRepository : IRepository<Product>
    {
        

    }
    public class ProducRepository : RepositoryBase<Product>,IProducRepository
    {
        public ProducRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}