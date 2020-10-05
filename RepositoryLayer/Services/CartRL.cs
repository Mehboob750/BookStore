using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommanLayer.Model;
using CommanLayer.ResponseModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class CartRL : ICartRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        private readonly IConfiguration configuration;

        CartResponseModel cartResponse = new CartResponseModel();

        CartModel cartModel = new CartModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public CartRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public CartResponseModel AddToCart(int claimId, int BookId)
        {
            try
            {
                var response = this.dbContext.Books.FirstOrDefault(value => ((value.BookId == BookId)) && ((value.IsDeleted == "No")) && ((value.Quantity >=1)));
                if (response != null)
                {
                    cartModel.UserId = claimId;
                    cartModel.BookId = response.BookId;
                    cartModel.CreatedDate = DateTime.Now;
                    cartModel.IsDeleted = "No";
                    this.dbContext.Cart.Add(cartModel);
                    this.dbContext.SaveChanges();
                    return Response(cartModel);
                }
                return cartResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CartResponseModel> GetAllCartValues()
        {
            try
            {
                List<CartResponseModel> cartResponseList = new List<CartResponseModel>();
                var cartResponse = this.dbContext.Cart;
                foreach (var response in cartResponse)
                {
                    CartResponseModel cart = new CartResponseModel();
                    if (response.IsDeleted == "No")
                    {
                        cart = Response(response);
                        cartResponseList.Add(cart);
                    }
                   
                }
                return cartResponseList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CartResponseModel DeleteFromCart(int CartId)
        {
            try
            {
                var response = this.dbContext.Cart.FirstOrDefault(value => ((value.CartId == CartId)) && ((value.IsDeleted == "No")));
                if (response != null)
                {
                    response.IsDeleted = "Yes";
                    this.dbContext.Cart.Update(response);
                    this.dbContext.SaveChanges();
                    return Response(response);
                }
                return cartResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CartResponseModel Response(CartModel cartModel)
        {
            CartResponseModel cart = new CartResponseModel();
            cart.CartId = cartModel.CartId;
            cart.UserId = cartModel.UserId;
            cart.BookId = cartModel.BookId;
            cart.CreatedDate = cartModel.CreatedDate;
            return cart;
        }
    }
}
