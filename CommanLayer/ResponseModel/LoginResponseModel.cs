using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.ResponseModel
{
    public class LoginResponseModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the UserType
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the Registration Date
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        public string Token { get; set; }
    }
}
