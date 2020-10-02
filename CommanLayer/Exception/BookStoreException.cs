using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.Exception
{
    public class BookStoreException : SystemException
    {
        /// <summary>
        /// Parameterized constructor used to Initialize type of Exception
        /// </summary>
        /// <param name="type">It contains the type of Exception</param>
        /// <param name="message">It contains the message</param>
        public BookStoreException(BookStoreException.ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// It is used for Null Field
            /// </summary>
            NULL_FIELD_EXCEPTION,

            /// <summary>
            /// It is Used for Empty Field
            /// </summary>
            EMPTY_FIELD_EXCEPTION,

            INVALID_FIELD_EXCEPTION
        }

        /// <summary>
        /// Gets or Sets Exception Type
        /// </summary>
        public ExceptionType Type { get; set; }
    }
}
