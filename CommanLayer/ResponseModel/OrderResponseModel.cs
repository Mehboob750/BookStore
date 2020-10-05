using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.ResponseModel
{
    public class OrderResponseModel
    {
        /// <summary>
        /// Gets or sets the OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the CartId
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the BookId
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        public int AddressID { get; set; }

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
        public string PinCode { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the ModificationDate
        /// </summary>
        public DateTime ModificationDate { get; set; }
    }
}
