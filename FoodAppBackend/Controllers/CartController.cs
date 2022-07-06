using DataAccessLayer;
using FoodAppBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCart(int id)
        {
            try
            {
                return Ok(await _cartRepository.GetCart(id));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "INTERNAL SERVER ERROR");
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCart(Cart cart)
        {
            try
            {
                return Ok(await _cartRepository.UpdateCart(cart));

            }
            catch (Exception ex)
            {
                return StatusCode(200, "SAVED SUCCESSFULLY");
            }
        }


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
