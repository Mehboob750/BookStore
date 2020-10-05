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
    public class WishListController : Controller
    {
        private IWishListBL wishListBuiseness;

        public WishListController(IWishListBL wishListBuiseness)
        {
            this.wishListBuiseness = wishListBuiseness;
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Roles = "User")]
        public IActionResult AddToWishList(int BookId)
        {
            try
            {
                int claimId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

                // Call the AddToWishList Method of Cart class
                var response = this.wishListBuiseness.AddToWishList(claimId, BookId);

                // check if Id is not equal to zero
                if (!response.BookId.Equals(0))
                {
                    bool status = true;
                    var message = "Book Added To Wish List Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Add Wish List";
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
        public IActionResult GetAllWishListValues()
        {
            try
            {
                // Call the GetAllWishListValues Method of Cart class
                var response = this.wishListBuiseness.GetAllWishListValues();

                // check if Id is not equal to zero
                if (!response.Count.Equals(0))
                {
                    bool status = true;
                    var message = "WishList Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "WishList is Empty";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
        [HttpDelete]
        [Route("{WishListId}")]
        [AllowAnonymous]
        //[Authorize(Roles = "User")]
        public IActionResult DeleteFromWishList([FromRoute] int WishListId)
        {
            try
            {
                // Call the AddToCart Method of Cart class
                var response = this.wishListBuiseness.DeleteFromWishList(WishListId);

                // check if Id is not equal to zero
                if (!response.WishListId.Equals(0))
                {
                    bool status = true;
                    var message = "Deleted From WishList Successfully";
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

        [HttpPost]
        [Route("MoveToCart")]
        [AllowAnonymous]
        //[Authorize(Roles = "User")]
        public IActionResult MoveToCart(int WishListId)
        {
            try
            {
                int claimId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);

                // Call the MoveToCart Method of Cart class
                var response = this.wishListBuiseness.MoveToCart(claimId, WishListId);

                // check if Id is not equal to zero
                if (!response.WishListId.Equals(0))
                {
                    bool status = true;
                    var message = "Successfully Move To Cart";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Move";
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