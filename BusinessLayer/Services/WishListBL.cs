using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommanLayer.ResponseModel;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace BusinessLayer.Services
{
    public class WishListBL : IWishListBL
    {
        /// <summary>
        /// Created the Reference of IWishListBL
        /// </summary>
        private readonly IWishListRL wishListRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishListBL"/> class.
        /// </summary>
        /// <param name="wishListRepository">It contains the object ICartRL</param>
        public WishListBL(IWishListRL wishListRepository)
        {
            this.wishListRepository = wishListRepository;
        }

        public WishListResponseModel AddToWishList(int claimId, int BookId)
        {
            try
            {
                // Call the AddToWishList Method of Cart Repository Class
                var response = this.wishListRepository.AddToWishList(claimId, BookId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
