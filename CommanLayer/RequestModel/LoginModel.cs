using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer.RequestModel
{
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the UserType
        /// </summary>
        [Required]
        [RegularExpression("(?:Admin|admin|User|user)$", ErrorMessage = "Role Should be User/Admin")]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        [Required]
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [RegularExpression("^.{8,30}$", ErrorMessage = "Password Length should be between 8 to 15")]
        [Required]
        public string Password { get; set; }
    }
}
