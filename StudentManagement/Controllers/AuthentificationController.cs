using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }


        private class StudentInfoUser
        {
            public int StudentId { get; set; }
            public string UserName { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string City { get; set; }

            public StudentInfoUser(int studentId,string userName , string firstName,string lastName , string city)
            {
                StudentId = studentId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                City = city;
            }

        }


        public AuthentificationController(IConfiguration configuration)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }












        [HttpPost("authenticate")]
        public ActionResult<string> Authentiticate( AuthenticationRequestBody authenticationRequestBody)
        {
            //step 1: validate the usenme and password

            var user = ValidateUserCredntial(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            if(user == null)
            {
                return Unauthorized();
            }

            //step 2: Create a token

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecreteKey"]));
            var singingCredential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            //the claims that
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.StudentId.ToString()));
            claimsForToken.Add(new Claim("given_name",user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("city", user.City));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                singingCredential);


            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn);

        }

        private StudentInfoUser ValidateUserCredntial(string? userName, string? password)
        {
            //if i have user db or tabel,i just check passed-throught username/password against who stored in database
            return new StudentInfoUser(
                1,
                userName ?? "",
                "Florin",
                "furdui",
                "sebes");
        }
    }
}
