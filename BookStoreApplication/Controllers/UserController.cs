using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer.Exception;
using CommanLayer.Model;
using CommanLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserBL userBuiseness;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userBusiness">It is an object of IUser Business</param>
        public UserController(IUserBL userBuiseness)
        {
            this.userBuiseness = userBuiseness;
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
    }
}
