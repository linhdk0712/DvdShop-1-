namespace DvdShop.Models.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
