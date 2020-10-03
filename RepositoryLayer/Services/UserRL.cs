using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommanLayer.Model;
using CommanLayer.PasswordEncrypt;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        UserModel userModel = new UserModel();
        UserResponseModel userResponse = new UserResponseModel();
        LoginResponseModel loginResponse = new LoginResponseModel();
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public UserRL(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// It creates the object of EncryptDecrypt class
        /// </summary>
        private EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

        /// <summary>
        /// This Method is used to add new Record
        /// </summary>
        /// <param name="quantity">It contains the Object of Quantity Model</param>
        /// <returns>It returns Added Record</returns>
        public UserResponseModel UserRegistration(RegisterationModel registerationModel)
        {
            try
            {
                //UserResponseModel userResponse = new UserResponseModel();
                // this varibale stores the Encrypted password
                string password = this.encryptDecrypt.EncodePasswordToBase64(registerationModel.Password);
                var result = this.dbContext.UserDetails.FirstOrDefault(value => ((value.FirstName == registerationModel.FirstName)) && ((value.LastName == registerationModel.LastName)) && ((value.EmailId == registerationModel.EmailId)));
                if (result == null)
                {
                    userModel.FirstName = registerationModel.FirstName;
                    userModel.LastName = registerationModel.LastName;
                    userModel.Gender = registerationModel.Gender;
                    userModel.EmailId = registerationModel.EmailId;
                    userModel.PhoneNumber = registerationModel.PhoneNumber;
                    userModel.Password = password;
                    userModel.Role = registerationModel.Role;
                    userModel.RegistrationDate = DateTime.Now;
                    this.dbContext.UserDetails.Add(userModel);
                    this.dbContext.SaveChanges();
                }
                else
                {
                    return userResponse;
                }
                return Response(userModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LoginResponseModel UserLogin(LoginModel loginModel)
        {
            try
            {
                //UserResponseModel userResponse = new UserResponseModel();
                // return this.dbContext.Quantities.Find(id);
                string password = this.encryptDecrypt.EncodePasswordToBase64(loginModel.Password);
                // Call the User Register Method of User Repository Class
                var response = this.dbContext.UserDetails.FirstOrDefault(value => ((value.EmailId == loginModel.EmailId))&& ((value.Password == password)));            
                if (response != null)
                {
                    loginResponse.Id = response.Id;
                    loginResponse.FirstName = response.FirstName;
                    loginResponse.LastName = response.LastName;
                    loginResponse.Gender = response.Gender;
                    loginResponse.EmailId = response.EmailId;
                    loginResponse.PhoneNumber = response.PhoneNumber;
                    loginResponse.Role = response.Role;
                    loginResponse.RegistrationDate = response.RegistrationDate;
                    return loginResponse;
                }
                return loginResponse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }

        public UserResponseModel Response(UserModel userModel)
        {
            UserResponseModel userResponse = new UserResponseModel();
            userResponse.Id = userModel.Id;
            userResponse.FirstName = userModel.FirstName;
            userResponse.LastName = userModel.LastName;
            userResponse.Gender = userModel.Gender;
            userResponse.EmailId = userModel.EmailId;
            userResponse.PhoneNumber = userModel.PhoneNumber;
            userResponse.Role = userModel.Role;
            userResponse.RegistrationDate = userModel.RegistrationDate;
            return userResponse;
        }
    }
}
