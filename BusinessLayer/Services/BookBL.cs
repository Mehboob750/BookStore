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
        private readonly IBookRL bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookBL"/> class.
        /// </summary>
        /// <param name="adminRepository">It contains the object IUserRepository</param>
        public BookBL(IBookRL bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public BookResponse addBook(BookRequestModel createBookModel)
        {
            try
            {
                // Call the AddBook Method of Books Repository Class
                var response = this.bookRepository.AddBook(createBookModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BookResponse> GetAllBooks()
        {
            try
            {
                // Call the GetAllBooks Method of Books Repository Class
                var response = this.bookRepository.GetAllBooks();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public BookResponse UpdateBook(int Id, BookRequestModel updateBookModel)
        {
            try
            {
                // Call the AddBook Method of Books Repository Class
                var response = this.bookRepository.UpdateBook(Id,updateBookModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public BookResponse DeleteBook(int Id)
        {
            try
            {
                // Call the AddBook Method of Books Repository Class
                var response = this.bookRepository.DeleteBook(Id);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public BookResponse SearchBook(int Id)
        {
            try
            {
                // Call the GetAllBooks Method of Books Repository Class
                var response = this.bookRepository.SearchBook(Id);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
