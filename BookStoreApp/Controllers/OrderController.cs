using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderBL orderBuiseness;

        public OrderController(IOrderBL orderBuiseness)
        {
            this.orderBuiseness = orderBuiseness;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult BookOrder(int CartId)
        {
            try
            {
                int claimId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

                // Call the BookOrder Method of Cart class
                var response = this.orderBuiseness.BookOrder(claimId, CartId);

                // check if OrderId is not equal to zero
                if (!response.OrderId.Equals(0))
                {
                    bool status = true;
                    var message = "Order Book Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Book Order";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
    }
}
