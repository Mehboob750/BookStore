﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer.RequestModel
{
    public class RegisterationModel
    {
        /// <summary>
        /// Gets or sets the First name
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "First Name is not valid")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last name
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Last Name is not valid")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Gender
        /// </summary>
        [Required]
        [RegularExpression("(?:m|M|male|Male|f|F|female|Female)$", ErrorMessage = "Gender is not valid")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        [Required]
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the Phone Number
        /// </summary>
        [RegularExpression("([1-9]{1}[0-9]{9})$", ErrorMessage = "Phone number is not valid")]
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the UserType
        /// </summary>
        [Required]
        [RegularExpression("(?:Admin|admin|User|user)$", ErrorMessage = "Role Should be User/Admin")]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [RegularExpression("^.{8,30}$", ErrorMessage = "Password Length should be between 8 to 15")]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "City is not valid")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "State is not valid")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Pincode
        /// </summary>
        [Required]
        [RegularExpression("^.{6}$", ErrorMessage = "Pincode is not valid")]
        public string Pincode { get; set; }
    }
}
