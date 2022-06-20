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
        public FoodController(IFoodRepository foodRepository)
        {
                _foodRepository = foodRepository;
        }
       [HttpGet]
       public async Task<IActionResult> GetFood()
        {
            try
            {
            return Ok(await _foodRepository.GetFood());

            }catch (Exception ex)
            {
                return StatusCode(500, "NO FOOD FOUND");
            }
        }
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
       [HttpPost]
       public async Task<IActionResult> AddFood(Food food)
        {
            try
            {
                if (food.Id > 0) {
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
    

    }
}
