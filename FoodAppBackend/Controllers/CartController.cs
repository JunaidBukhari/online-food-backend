using FoodApp.Interfaces;
using FoodApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        /// <summary>
        /// Constructor Dependency Injection for using the cart reporsitory
        /// </summary>
        /// <param name="cartRepository">Domain Cart Model Services</param>
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        /// <summary>
        /// HttpGet request to get the specific Card data
        /// </summary>
        /// <param name="id">the requested id of card</param>
        /// <returns>200 response with Cart Detail</returns>
        /// <error>404 No Item Found</error>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCart(int id)
        {
            try
            {
                return Ok(await _cartRepository.GetCart(id));

            }
            catch (Exception ex)
            {
                return StatusCode(404, "No Item Found");
            }
        }


        /// <summary>
        /// HttpPost request to update the card data
        /// </summary>
        /// <param name="cart">updated cart Data</param>
        /// <returns>updated cart data (200)</returns>
        /// <error>Error while updating (404)</error>
        [HttpPost]
        public async Task<IActionResult> UpdateCart(Cart cart)
        {
            try
            {
                return Ok(await _cartRepository.UpdateCart(cart));

            }
            catch (Exception ex)
            {
                return StatusCode(404, "Error While updating the cart");
            }
        }


        /// <summary>
        /// HttpDelete request to delelte the cart data
        /// </summary>
        /// <param name="id">Deleted cart id</param>
        /// <returns>Deleted Cart Data (200)</returns>
        /// <error>400 Bad Request</error>
        [HttpDelete("{id:int}")]
        public async Task<OkObjectResult> DeleteCart(int id)
        {

            try
            {

                return Ok(await _cartRepository.DeleteCart(id));
            }
            catch (Exception ex)
            {
                return (OkObjectResult)StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
