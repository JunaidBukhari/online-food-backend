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
    }
}
