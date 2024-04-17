namespace Bulky.DataAccess.Persistence.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        int Complete();
    }
}
