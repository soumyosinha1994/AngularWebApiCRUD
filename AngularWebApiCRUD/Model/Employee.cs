using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AngularWebApiCRUD.Model
{
    public class Employee
    {
        //[Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string? Password { get; set; }
    }
}
