using AngularWebApiCRUD.DTO;
using Microsoft.EntityFrameworkCore;

namespace AngularWebApiCRUD.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        public DbSet<EmployeeDTO> Employees { get; set; }
    }
}
