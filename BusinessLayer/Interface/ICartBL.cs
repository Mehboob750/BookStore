using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.ResponseModel;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        CartResponseModel AddToCart(int claimId, int BookId);
    }
}
