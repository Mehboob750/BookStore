using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        BookResponse addBook(CreateBookModel createBookModel);
    }
}
