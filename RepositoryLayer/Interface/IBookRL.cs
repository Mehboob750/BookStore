using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        BookResponse AddBook(BookRequestModel createBookModel);

        List<BookResponse> GetAllBooks();

        BookResponse UpdateBook(int Id, BookRequestModel updateBookModel);

        BookResponse DeleteBook(int Id);

        BookResponse SearchBook(int Id);
    }
}
