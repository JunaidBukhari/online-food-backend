using DataAccessLayer;
using FoodAppBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;

        /// <summary>
        /// Constructor used to access the food repository and food services
        /// </summary>
        /// <param name="foodRepository">food repository</param>
        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        /// <summary>
        /// HttpGet requests to get all foods
        /// </summary>
        /// <returns>All the food Item</returns>
        /// <error>Not Found (404)</error>
        [HttpGet]
        public async Task<IActionResult> GetFood()
        {
            try
            {
                return Ok(await _foodRepository.GetFood());

            }
            catch (Exception ex)
            {
                return StatusCode(404, "NO FOOD FOUND");
            }
        }

        /// <summary>
        /// HttpDelete request to delete the specific food
        /// </summary>
        /// <param name="id">ID of Food</param>
        /// <returns>Deleted Food Item Data (200)</returns>
        /// <error>Bad Request (400)</error>
        [HttpDelete("{id:int}")]
        public async Task<OkObjectResult> DeleteFood(int id)
        {

            try
            {

                return Ok(await _foodRepository.DeleteFood(id));
            }
            catch (Exception ex)
            {
                return (OkObjectResult)StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// HttpPost request to create the food
        /// </summary>
        /// <param name="food">Food Data</param>
        /// <returns>Create / updated food item data (200)</returns>
        /// <error>Bad Request (400)</error>
        [HttpPost]
        public async Task<IActionResult> AddFood(Food food)
        {
            try
            {
                if (food.Id > 0)
                {
                    return Ok(await _foodRepository.UpdateFood(food));

                }
                else
                {
                    return Ok(await _foodRepository.AddFood(food));

                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// HttpPost request to rate the food items
        /// </summary>
        /// <param name="food">Food Item</param>
        /// <returns>Rated food item data</returns>
        /// <error>Server Error (500)</error>
        [HttpPost("rate")]
        public async Task<IActionResult> RateFood(Food food)
        {

            try
            {

                return Ok(await _foodRepository.RateFood(food));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error");
            }
        }

    }
}
