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
    public class CartController : Controller
    {
        private ICartBL cartBuiseness;

        public CartController(ICartBL cartBuiseness)
        {
            this.cartBuiseness = cartBuiseness;
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Roles = "User")]
        public IActionResult AddToCart(int BookId)
        {
            try
            {
                int claimId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

                // Call the AddToCart Method of Cart class
                var response = this.cartBuiseness.AddToCart(claimId, BookId);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Added To Cart Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Add Cart";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Roles = "User")]
        public IActionResult GetAllCartValues()
        {
            try
            {
                // Call the AddToCart Method of Cart class
                var response = this.cartBuiseness.GetAllCartValues();

                // check if Id is not equal to zero
                if (!response.Count.Equals(0))
                {
                    bool status = true;
                    var message = "Cart Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Cart is Empty";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpDelete]
        [Route("{CartId}")]
        [AllowAnonymous]
        //[Authorize(Roles = "User")]
        public IActionResult DeleteFromCart([FromRoute] int CartId)
        {
            try
            {
                // Call the AddToCart Method of Cart class
                var response = this.cartBuiseness.DeleteFromCart(CartId);

                // check if Id is not equal to zero
                if (!response.CartId.Equals(0))
                {
                    bool status = true;
                    var message = "Deleted From Cart Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Delete";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
    }
}
