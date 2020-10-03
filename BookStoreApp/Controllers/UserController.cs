using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer.Exception;
using CommanLayer.Model;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IConfiguration configuration;

        private IUserBL userBuiseness;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userBusiness">It is an object of IUser Business</param>
        public UserController(IUserBL userBuiseness, IConfiguration configuration)
        {
            this.userBuiseness = userBuiseness;
            this.configuration = configuration;
        }

        /// <summary>
        /// This Method is used for User Registration
        /// </summary>
        /// <param name="registerationModel">It is an object of User Model</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        [Route("Registration")]
        [AllowAnonymous]
        public IActionResult UserRegistration(RegisterationModel registerationModel)
        {
            try
            {
                if (registerationModel.FirstName == null || registerationModel.LastName == null || registerationModel.Role == null || registerationModel.EmailId == null || registerationModel.PhoneNumber == null || registerationModel.Gender == null || registerationModel.Password == null)
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Variable Field");
                }
                else if (registerationModel.FirstName == "" || registerationModel.LastName == "" || registerationModel.Role == "" || registerationModel.EmailId == "" || registerationModel.PhoneNumber == "" || registerationModel.Gender == "" || registerationModel.Password == "")
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Variable Field");
                }

                // Call the User Registration Method of User Business classs
                var response = this.userBuiseness.UserRegistration(registerationModel);

                // check if Id is not equal to zero
                if (!response.EmailId.Equals(null))
                {
                    bool status = true;
                    var message = "User Registered Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "User already Present";
                    return this.Conflict(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used for User Registration
        /// </summary>
        /// <param name="loginModel">It is an object of Login Model</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult UserLogin(LoginModel loginModel)
        {
            try
            {
                if (loginModel.Role == null || loginModel.EmailId == null || loginModel.Password == null)
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Variable Field");
                }
                else if (loginModel.Role == "" || loginModel.EmailId == "" || loginModel.Password == "")
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Variable Field");
                }

                // Call the User Registration Method of User Business classs
                var response = this.userBuiseness.UserLogin(loginModel);

                // check if Id is not equal to zero
                if (!response.Id.Equals(0))
                {
                    string token = this.CreateToken(response);
                    response.Token = token;
                    bool status = true;
                    var message = "Login Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Login Failed";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        private string CreateToken(LoginResponseModel userLoginModel)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, userLoginModel.Role.ToString()));
                claims.Add(new Claim("Id", userLoginModel.Id.ToString()));
                claims.Add(new Claim("EmailId", userLoginModel.EmailId.ToString()));
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
