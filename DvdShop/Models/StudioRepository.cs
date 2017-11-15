using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models
{
    public interface IStudioRepository : IRepository<Studio>
    {
        
    }
    public class StudioRepository : RepositoryBase<Studio>,IStudioRepository
    {
        public StudioRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}