using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommanLayer.ResponseModel;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class CartBL : ICartBL
    {
        /// <summary>
        /// Created the Reference of IcartRL
        /// </summary>
        private readonly ICartRL cartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartBL"/> class.
        /// </summary>
        /// <param name="cartRepository">It contains the object ICartRL</param>
        public CartBL(ICartRL cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public CartResponseModel AddToCart(int claimId, int BookId)
        {
            try
            {
                // Call the AddToCart Method of Cart Repository Class
                var response = this.cartRepository.AddToCart(claimId, BookId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
