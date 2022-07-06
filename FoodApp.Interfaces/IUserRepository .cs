using FoodApp.Model;

namespace FoodApp.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> Login(string email, string password);
        public Task<User> SignUp(User user);
        public Task<User> TotalOrders(User user);

    }
}
