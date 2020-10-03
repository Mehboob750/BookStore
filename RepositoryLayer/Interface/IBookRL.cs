using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.RequestModel;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        BookResponse AddBook(CreateBookModel createBookModel);
    }
}
