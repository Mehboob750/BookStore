using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        /// <summary>
        /// Created the Reference of IUserRepository
        /// </summary>
        private readonly IBookRL adminRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookBL"/> class.
        /// </summary>
        /// <param name="adminRepository">It contains the object IUserRepository</param>
        public BookBL(IBookRL adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public BookResponse addBook(CreateBookModel createBookModel)
        {
            try
            {
                // Call the User Register Method of User Repository Class
                var response = this.adminRepository.AddBook(createBookModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
    }
}
