using DataAccessLayer;
using FoodAppBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
   [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMyOrder(int id)
        {
            try
            {
                return Ok(await _orderRepository.GetMyOrders(id));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "INTERNAL SERVER ERROR");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                return Ok(await _orderRepository.GetOrders());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "INTERNAL SERVER ERROR");
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            try
            {
                return Ok(await _orderRepository.UpdateOrder(order));

            }
            catch (Exception ex)
            {
                return StatusCode(200, "SAVED SUCCESSFULLY");
            }
        }


   [HttpDelete("{id:int}")]
        public async Task<OkObjectResult> DeleteOrder(int id)
        {

            try
            {

                return Ok(await _orderRepository.DeleteOrder(id));
            }
            catch (Exception ex)
            {
                return (OkObjectResult)StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
