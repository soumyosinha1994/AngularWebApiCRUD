using AngularWebApiCRUD.Data;
using AngularWebApiCRUD.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AngularWebApiCRUD.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
       private readonly ApplicationContext _context;
        internal DbSet<T> DbSet;
        public Repository(ApplicationContext context)
        {
            _context = context;
            DbSet=_context.Set<T>();
        }

        public async Task Add(T entity)
        {
            DbSet.Add(entity);
        }


        public async Task Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, bool Tracking = false)
        {
            if (Tracking)
            {
                return DbSet.Where(filter).FirstOrDefault();
            }
            else
            {
                return DbSet.AsNoTracking().Where(filter).FirstOrDefault();
            }
          
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            return DbSet.ToList();
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
