using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Model
{
    public class WishListModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListID { get; set; }

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

        /// <summary>
        /// Gets or sets the IsMoved
        /// </summary>
        public string IsMoved { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted
        /// </summary>
        public string IsDeleted { get; set; }
    }
}
