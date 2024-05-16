using AngularWebApiCRUD.Data;
using AngularWebApiCRUD.DTO;
using AngularWebApiCRUD.IRepository;

namespace AngularWebApiCRUD.Repository
{
    public class EmployeeRepository:Repository<EmployeeDTO>,IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }
    }
}
