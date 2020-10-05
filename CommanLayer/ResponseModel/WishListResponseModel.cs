using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.ResponseModel
{
    public class WishListResponseModel
    {
        /// <summary>
        /// Gets or sets the WishListId
        /// </summary>
        public int WishListId { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the BookId
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
