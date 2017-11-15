using System;

namespace DvdShop.Models.Repositories
{
    public interface IDbFactory : IDisposable
    {
        DvdDbContext GetDbContext();
    }
}
