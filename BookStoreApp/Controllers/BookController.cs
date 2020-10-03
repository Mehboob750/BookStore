using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer.Exception;
using CommanLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookBL bookBuiseness;

        public BookController(IBookBL bookBuiseness)
        {
            this.bookBuiseness = bookBuiseness;
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles ="Admin")]
        public IActionResult AddBook([FromForm] BookRequestModel createBookModel)
        {
            try
            {
                if (createBookModel.BookName == null || createBookModel.AuthorName == null || createBookModel.Description == null || createBookModel.Price == null)
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Variable Field");
                }
                else if (createBookModel.BookName == "" || createBookModel.AuthorName == "" || createBookModel.Description == "" || createBookModel.Price == "")
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Variable Field");
                }

                // Call the User Add Book Method of User Admin classs
                var response = this.bookBuiseness.addBook(createBookModel);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Added Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed to add";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBooks()
        {
            try
            {
                // Call the User GetAllBooks Method of BookBL classs
                var response = this.bookBuiseness.GetAllBooks();

                // check if Id is not equal to zero
                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Books Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed to Read";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpPut]
        [Route("{Id}")]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBook([FromRoute] int Id,[FromForm] BookRequestModel updateBookModel)
        {
            try
            {
                if (updateBookModel.BookName == null || updateBookModel.AuthorName == null || updateBookModel.Description == null || updateBookModel.Price == null)
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Variable Field");
                }
                else if (updateBookModel.BookName == "" || updateBookModel.AuthorName == "" || updateBookModel.Description == "" || updateBookModel.Price == "")
                {
                    throw new BookStoreException(BookStoreException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Variable Field");
                }

                // Call the User Add Book Method of BookBL classs
                var response = this.bookBuiseness.UpdateBook(Id, updateBookModel);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Updated Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "BookId Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBook([FromRoute] int Id)
        {
            try
            {
                // Call the User Add Book Method of BookBL classs
                var response = this.bookBuiseness.DeleteBook(Id);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Deleted Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Book Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult SearchBook(int Id)
        {
            try
            {
                // Call the User GetAllBooks Method of BookBL classs
                var response = this.bookBuiseness.SearchBook(Id);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Book Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
    }
}
