namespace ProyectoECI.Web.Data.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T : class
    {
        //SELECT *
        IQueryable<T> GetAll();

        //SELECT CON WHERE
        Task<T> GetByIdAsyn(int id);

        //SELECT CON WHERE
        Task<T> FindByIdAsyn(int id);

        //METODOS CRUD
        Task<T> CreateAsyn(T entity);

        Task<T> UpdateAsyn(T entity);

        Task DeleteAsyn(T entity);

        Task<bool> ExistAsyn(int id);
    }
}
