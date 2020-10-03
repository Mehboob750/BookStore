using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        BookResponse AddBook(CreateBookModel createBookModel);

        List<BookResponse> GetAllBooks();
    }
}
