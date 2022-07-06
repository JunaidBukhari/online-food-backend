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

        /// <summary>
        /// Constructor used to get the user repository
        /// </summary>
        /// <param name="userRepository">User repository services</param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// HttpGet request to get all users
        /// </summary>
        /// <returns>OK response with all users informations</returns>
        /// <error>404 Status Code error if not found</error>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());

            }
            catch (Exception ex)
            {
                return StatusCode(404, "NO User FOUND");
            }
        }

        /// <summary>
        /// HttpPost request to login the user
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>OK response if successfull</returns>
        /// <error>404 Status Code error if not found</error>
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {

            try
            {
                string email = user.Email;
                string password = user.Password;
                return Ok(await _userRepository.Login(email, password));

            }
            catch (Exception ex)
            {
                return StatusCode(404, "NO User FOUND");
            }
        }


        /// <summary>
        /// HttpPost request to update the user
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>OK response with updated user data</returns>
        /// <error>500 Error while updating the user</error>
        [HttpPost("orders")]
        public async Task<IActionResult> UpdateUser(User user)
        {

            try
            {

                return Ok(await _userRepository.TotalOrders(user));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while updating the user");
            }
        }

        /// <summary>
        /// HttpPost request to signUp the user
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>OK response with user information</returns>
        /// <error>500 Error while signup the user</error>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(User user)
        {

            try
            {

                return Ok(await _userRepository.SignUp(user));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error while signup the user");
            }
        }

    }
}
