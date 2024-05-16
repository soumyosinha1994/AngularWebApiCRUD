using AngularWebApiCRUD.IService;
using AngularWebApiCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularWebApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private IEmployeeService _employeeService;
        private readonly JwtOption _options;
        public AuthenticationController(IEmployeeService employeeService, IOptions<JwtOption> options)
        {
            _employeeService= employeeService;
            _options = options.Value;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var Employee = await _employeeService.GetEmployee(x => x.Email==login.Email);
            if (Employee == null)
            {
                return BadRequest(new {error="Email Not Found"});
            }
            if(Employee.Password!=login.Password)
            {
                return BadRequest(new { error = "Password is incorrect" });
            }

            var token = GetJWTToken(login.Email);
            return Ok(new { token = token });
        }
        private string GetJWTToken(string email)
        {
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var crendential = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Email",email)
            };
            var sToken = new JwtSecurityToken(_options.Key, _options.Issuer, claims, expires: DateTime.Now.AddHours(5), signingCredentials: crendential);
            var token = new JwtSecurityTokenHandler().WriteToken(sToken);
            return token;
        }
    }
}
