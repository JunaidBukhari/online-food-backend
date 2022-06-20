using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _Context2;

        public UserRepository(ApplicationDbContext Context)
        {
            _Context2 = Context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _Context2.Users.ToListAsync();
        }

        public async Task<User> Login(string email, string password)
        {
            var result =  _Context2.Users.Where(user=>user.Email==email).FirstOrDefault();
            
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

        public async Task<User> SignUp(User user)
        {
            
            var result = await _Context2.Users.AddAsync(user);
            await _Context2.SaveChangesAsync();
            return result.Entity;
        }

        public Task<User> TotalOrders(User user)
        {
            throw new NotImplementedException();
        }

     
    }
}
