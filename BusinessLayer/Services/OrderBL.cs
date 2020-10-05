using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommanLayer.ResponseModel;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        /// <summary>
        /// Created the Reference of IcartRL
        /// </summary>
        private readonly IOrderRL orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBL"/> class.
        /// </summary>
        /// <param name="orderRepository">It contains the object ICartRL</param>
        public OrderBL(IOrderRL orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public OrderResponseModel BookOrder(int claimId, int CartId)
        {
            try
            {
                // Call the BookOrder Method of Cart Repository Class
                var response = this.orderRepository.BookOrder(claimId, CartId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
