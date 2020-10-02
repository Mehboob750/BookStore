using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommanLayer.Model;
using CommanLayer.PasswordEncrypt;
using CommanLayer.RequestModel;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

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
        public UserModel UserRegistration(RegisterationModel registerationModel)
        {
            try
            {
                UserModel userModel = new UserModel();
                
                // this varibale stores the Encrypted password
                string password = this.encryptDecrypt.EncodePasswordToBase64(registerationModel.Password);
                var result = this.dbContext.UserDetails.FirstOrDefault(value => ((value.EmailId == userModel.EmailId)));
                if (result == null)
                {
                    userModel.FirstName = registerationModel.FirstName;
                    userModel.LastName = registerationModel.LastName;
                    userModel.Gender = registerationModel.Gender;
                    userModel.EmailId = registerationModel.EmailId;
                    userModel.PhoneNumber = registerationModel.PhoneNumber;
                    userModel.Password = password;
                    userModel.Role = registerationModel.Role;
                    this.dbContext.UserDetails.Add(userModel);
                    this.dbContext.SaveChanges();
                }
                else
                {
                    return userModel;
                }

                return userModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
