using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Model
{
    public class AddressModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddresstId { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Pincode
        /// </summary>
        public string Pincode { get; set; }

        /// <summary>
        /// Gets or sets the Registration Date
        /// </summary>
        public DateTime RegistrationDate { get; set; }
    }
}
