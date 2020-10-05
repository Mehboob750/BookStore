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
    public class OrderRL : IOrderRL
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private ApplicationDbContext dbContext;

        private readonly IConfiguration configuration;

        OrderResponseModel orderResponse = new OrderResponseModel();

        OrderModel orderModel = new OrderModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRL"/> class.
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public OrderRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public OrderResponseModel BookOrder(int claimId, int CartId)
        {
            try
            {
                var response = this.dbContext.Cart.FirstOrDefault(value => ((value.BookId == CartId)) && ((value.IsDeleted == "No")));
                if (response != null)
                {
                    orderModel.CartId = response.CartId;
                    orderModel.UserId = claimId;
                    orderModel.BookId = response.BookId;
                    var address = this.dbContext.UserAddress.FirstOrDefault(value => ((value.UserId == claimId)));
                    orderModel.AddressID = address.AddresstId;
                    orderModel.City = address.City;
                    orderModel.State = address.State;
                    orderModel.PinCode = address.Pincode;
                    var userData = this.dbContext.UserDetails.FirstOrDefault(value => ((value.Id == claimId)));
                    orderModel.PhoneNumber = userData.PhoneNumber;
                    orderModel.CreatedDate = DateTime.Now;
                    orderModel.ModificationDate = DateTime.Now;
                    this.dbContext.Order.Add(orderModel);
                    this.dbContext.SaveChanges();
                    return Response(orderModel);
                }
                return orderResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public OrderResponseModel Response(OrderModel orderModel)
        {
            OrderResponseModel order = new OrderResponseModel();
            order.OrderId = orderModel.OrderId;
            order.CartId = orderModel.CartId;
            order.UserId = orderModel.UserId;
            order.BookId = orderModel.BookId;
            order.City = orderModel.City;
            order.State = orderModel.State;
            order.PinCode = orderModel.PinCode;
            order.CreatedDate = orderModel.CreatedDate;
            order.ModificationDate = orderModel.ModificationDate;
            return order;
        }
    }
}
