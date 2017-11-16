using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models
{
    public interface IUserRepository : IRepository<User>
    {
        
    }
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}