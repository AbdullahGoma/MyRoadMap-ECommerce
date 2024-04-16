namespace Bulky.DataAccess.Persistence.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
