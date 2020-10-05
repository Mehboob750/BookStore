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
    public class WishListRL : IWishListRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        private readonly IConfiguration configuration;

        WishListResponseModel wishListResponse = new WishListResponseModel();

        WishListModel wishListModel = new WishListModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public WishListRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public WishListResponseModel AddToWishList(int claimId, int BookId)
        {
            try
            {
                var response = this.dbContext.Books.FirstOrDefault(value => ((value.BookId == BookId)) && ((value.IsDeleted == "No")) && ((value.Quantity >= 1)));
                if (response != null)
                {
                    wishListModel.UserId = claimId;
                    wishListModel.BookId = response.BookId;
                    wishListModel.CreatedDate = DateTime.Now;
                    wishListModel.IsDeleted = "No";
                    wishListModel.IsMoved = "No";
                    this.dbContext.WishList.Add(wishListModel);
                    this.dbContext.SaveChanges();
                    return Response(wishListModel);
                }
                return wishListResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<WishListResponseModel> GetAllWishListValues()
        {
            try
            {
                List<WishListResponseModel> wishListResponseList = new List<WishListResponseModel>();
                var wishListResponse = this.dbContext.WishList;
                foreach (var response in wishListResponse)
                {
                    WishListResponseModel wishList = new WishListResponseModel();
                    if (response.IsDeleted == "No")
                    {
                        wishList = Response(response);
                        wishListResponseList.Add(wishList);
                    }

                }
                return wishListResponseList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public WishListResponseModel Response(WishListModel wishListModel)
        {
            WishListResponseModel wishList = new WishListResponseModel();
            wishList.WishListId = wishListModel.WishListID;
            wishList.UserId = wishListModel.UserId;
            wishList.BookId = wishListModel.BookId;
            wishList.CreatedDate = wishListModel.CreatedDate;
            return wishList;
        }
    }
}
