using DataAccessLayer;
using FoodAppBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }
    [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "NO User FOUND");
            }
        }
        [HttpPost]
       public async Task<IActionResult> Login(User user)
        {
            try
            {
            return Ok(await _userRepository.Login(user));

            }catch (Exception ex)
            {
                return StatusCode(500, "NO User FOUND");
            }
        }
    
    

    }
}
