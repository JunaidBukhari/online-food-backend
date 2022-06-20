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
        public async Task<IActionResult> GetUsers()
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {

            try
            {
                string email = user.Email;
                string password = user.Password;
                return Ok(await _userRepository.Login(email,password));

            }catch (Exception ex)
            {
                return StatusCode(500, "NO User FOUND");
            }
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(User user)
        {

            try
            {
               
                return Ok(await _userRepository.SignUp(user));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while saving");
            }
        }

    }
}
