using AngularWebApiCRUD.DTO;
using AngularWebApiCRUD.IRepository;
using AngularWebApiCRUD.IService;
using AngularWebApiCRUD.Model;
using AutoMapper;
using System.Linq.Expressions;

namespace AngularWebApiCRUD.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddEmployee(EmployeeDTO employeeDTO)
        {
            await _unitOfWork.EmployeeRepository.Add(employeeDTO);
        }

        public async Task<EmployeeDTO> GetEmployee(Expression<Func<EmployeeDTO, bool>> filter, bool Tracking = false)
        {
            return await _unitOfWork.EmployeeRepository.Get(filter);
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployee(Expression<Func<EmployeeDTO, bool>> filter = null)
        {
            return await _unitOfWork.EmployeeRepository.GetAll();
        }
        public void save()
        {
            _unitOfWork.Save();
        }

        public async Task UpdateEmployee(EmployeeDTO employeeDTO)
        {
            await _unitOfWork.EmployeeRepository.Update(employeeDTO);
        }

        public async Task DeleteEmployee(EmployeeDTO employeeDTO)
        {
            await _unitOfWork.EmployeeRepository.Delete(employeeDTO);
        }
    }
}
