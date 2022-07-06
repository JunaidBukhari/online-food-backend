using FoodApp.Interfaces;
using FoodApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Constructor used to get the order repository
        /// </summary>
        /// <param name="orderRepository">Order repository services</param>
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// HttpGet request to get specific order
        /// </summary>
        /// <param name="id">specific order ID</param>
        /// <returns>Order Detial (200)</returns>
        /// <error>Not Found (404)</error>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMyOrder(int id)
        {
            try
            {
                return Ok(await _orderRepository.GetMyOrders(id));

            }
            catch (Exception ex)
            {
                return StatusCode(404, "Not Found");
            }
        }

        /// <summary>
        /// HttpGet request to get the all orders
        /// </summary>
        /// <returns>All orders data (200)</returns>
        /// <error>Not found (404)</error>
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                return Ok(await _orderRepository.GetOrders());

            }
            catch (Exception ex)
            {
                return StatusCode(404, "Not Found");
            }
        }


        /// <summary>
        /// HttpPost request to update the order
        /// </summary>
        /// <param name="order">Order Data</param>
        /// <returns>Updated Order Data (200)</returns>
        /// <error>Bad Request (400)</error>
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            try
            {
                return Ok(await _orderRepository.UpdateOrder(order));

            }
            catch (Exception ex)
            {
                return StatusCode(400, "Bad Request");
            }
        }


        /// <summary>
        /// HttpDelete request to Delete the specific order
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns>Delete order Item Data</returns>
        /// <error>Bad Request (400)</error>
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
