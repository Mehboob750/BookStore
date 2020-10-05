using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        CartResponseModel AddToCart(int claimId, int BookId);

        List<CartResponseModel> GetAllCartValues();

        CartResponseModel DeleteFromCart(int CartId);
    }
}
