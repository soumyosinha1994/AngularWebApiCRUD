namespace AngularWebApiCRUD.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        void Save();
    }
}
