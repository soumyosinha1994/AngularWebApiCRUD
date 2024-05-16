using AngularWebApiCRUD.DTO;
using System.Linq.Expressions;

namespace AngularWebApiCRUD.IService
{
    public interface IEmployeeService
    {
        public Task AddEmployee(EmployeeDTO employeeDTO);

        public Task<EmployeeDTO> GetEmployee(Expression<Func<EmployeeDTO, bool>> filter, bool Tracking = false);
        public Task<IEnumerable<EmployeeDTO>> GetAllEmployee(Expression<Func<EmployeeDTO, bool>> filter = null);
        public Task UpdateEmployee(EmployeeDTO employeeDTO);
        public Task DeleteEmployee(EmployeeDTO employeeDTO);

        void save();
    }
}
