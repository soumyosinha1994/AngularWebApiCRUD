using AngularWebApiCRUD.IRepository;
using AngularWebApiCRUD.IService;
using AngularWebApiCRUD.Model;
using AngularWebApiCRUD.Service;
using AutoMapper;
using Moq;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        public IEmployeeService _employeeService { get; set; }
        public Mock<IUnitOfWork> _unitOfWork { get; set; }
        public Mock<IRepository<Employee>> _repository { get; set; }
        private readonly IMapper _mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _unitOfWork= new Mock<IUnitOfWork>(_repository.Object);
            _repository=new Mock<IRepository<Employee>>(MockBehavior.Strict);
            _employeeService=new EmployeeService(_unitOfWork.Object, _mapper);

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}