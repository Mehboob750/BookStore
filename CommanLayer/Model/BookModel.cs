using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Model
{
    public class BookModel
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the BookName
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the AuthorName
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the ModificationDate
        /// </summary>
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted
        /// </summary>
        public string IsDeleted { get; set; }
    }
}
