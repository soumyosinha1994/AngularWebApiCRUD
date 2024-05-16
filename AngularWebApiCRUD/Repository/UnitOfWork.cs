using AngularWebApiCRUD.Data;
using AngularWebApiCRUD.IRepository;

namespace AngularWebApiCRUD.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
       public IEmployeeRepository EmployeeRepository { get; private set; }
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
