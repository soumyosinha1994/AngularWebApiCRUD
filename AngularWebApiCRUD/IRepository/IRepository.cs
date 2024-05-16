using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AngularWebApiCRUD.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        public Task<T> Get(Expression<Func<T, bool>> filter, bool Tracking = false);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
        
    }
}
