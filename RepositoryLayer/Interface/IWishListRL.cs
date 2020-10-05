using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.ResponseModel;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        WishListResponseModel AddToWishList(int claimId, int BookId);

        List<WishListResponseModel> GetAllWishListValues();
    }
}
