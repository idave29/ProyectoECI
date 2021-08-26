namespace ProyectoECI.Web.Data.Repositories
{
    using ProyectoECI.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _dataContext;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsyn(int id)
        {
            return await _dataContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> FindByIdAsyn(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateAsyn(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await SaveAllAsyn();
            return entity;
        }

        public async Task<T> UpdateAsyn(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await SaveAllAsyn();
            return entity;
        }

        public async Task DeleteAsyn(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            await SaveAllAsyn();
        }

        public async Task<bool> ExistAsyn(int id)
        {
            return await _dataContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAllAsyn()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
