using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Persistence.Contexts;

namespace TaskManager.Infrastructure.Repositories
{
    public class Repository<T>(TaskManagerDbContext context) : IRepository<T> where T : class
    {
        private readonly DbContext _context = context;


        public IQueryable<T> GetAll() => _context.Set<T>().AsQueryable();

        public T? GetById(int id) => _context.Set<T>().Find(id);

        public T Add(T entity) => _context.Set<T>().Add(entity).Entity;

        public T Update(T entity) => _context.Set<T>().Update(entity).Entity;

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public int SaveChanges() => _context.SaveChanges();
    }
}
