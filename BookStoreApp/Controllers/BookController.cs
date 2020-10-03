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
        private IAdminBL adminBuiseness;

        public BookController(IAdminBL adminBuiseness)
        {
            this.adminBuiseness = adminBuiseness;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult AddBook([FromForm] CreateBookModel createBookModel)
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
                var response = this.adminBuiseness.addBook(createBookModel);

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
    }
}
