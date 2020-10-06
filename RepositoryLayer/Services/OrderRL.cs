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
                    var address = this.dbContext.UserAddress.FirstOrDefault(value => ((value.UserId == claimId)));
                    orderModel.AddressID = address.AddresstId;
                    orderModel.IsActive = "Yes";
                    orderModel.IsPlaced = "No";
                    orderModel.Quantity = 1;
                    var book = this.dbContext.Books.FirstOrDefault(value => ((value.BookId == response.BookId)));
                    orderModel.TotalPrice = book.Price;
                    orderModel.CreatedDate = DateTime.Now;
                    orderModel.ModificationDate = DateTime.Now;
                    this.dbContext.Orders.Add(orderModel);
                    this.dbContext.SaveChanges();
                    response.IsDeleted = "Yes";
                    this.dbContext.Cart.Update(response);
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

        public List<OrderResponseModel> GetAllOrderValues()
        {
            try
            {
                List<OrderResponseModel> orderResponseList = new List<OrderResponseModel>();
                var orderResponse = this.dbContext.Orders;
                 foreach (var response in orderResponse)
                 {
                     OrderResponseModel order = new OrderResponseModel();
                     if (response.IsPlaced == "No")
                     {
                         order = Response(response);
                         orderResponseList.Add(order);
                     }
                 }
                 return orderResponseList;
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
            order.AddressID = orderModel.AddressID;
            order.IsActive = orderModel.IsActive;
            order.IsPlaced = orderModel.IsPlaced;
            order.Quantity = orderModel.Quantity;
            order.TotalPrice = orderModel.TotalPrice;
            order.CreatedDate = orderModel.CreatedDate;
            order.ModificationDate = orderModel.ModificationDate;
            return order;
        }
    }
}
