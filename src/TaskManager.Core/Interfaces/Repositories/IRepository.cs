namespace TaskManager.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T? GetById(int id);
        int SaveChanges();
        T Update(T entity);
    }
}