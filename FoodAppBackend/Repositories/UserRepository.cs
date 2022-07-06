using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _Context2;

        /// <summary>
        /// Constructor used to get the applicationDbContext
        /// </summary>
        /// <param name="Context">ApplicationDbContext</param>
        public UserRepository(ApplicationDbContext Context)
        {
            _Context2 = Context;
        }

        /// <summary>
        /// Method used to get list of users
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _Context2.Users.ToListAsync();
        }

        /// <summary>
        /// Method used to Login the user
        /// </summary>
        /// <param name="email">Email of User</param>
        /// <param name="password">Password of User</param>
        /// <returns>Result of login user</returns>
        public async Task<User> Login(string email, string password)
        {
            var result = _Context2.Users.Where(user => user.Email == email).FirstOrDefault();

            if (result != null)
            {
                if (password == result.Password)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Method used to SignUp the user
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>User Object</returns>
        public async Task<User> SignUp(User user)
        {

            var result = await _Context2.Users.AddAsync(user);
            await _Context2.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Method used to Update the User
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>Update user result</returns>
        public async Task<User> TotalOrders(User user)
        {
            var result = _Context2.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            result.Orders++;
            _Context2.Users.Update(result);
            await _Context2.SaveChangesAsync();
            return result;

        }


    }
}
