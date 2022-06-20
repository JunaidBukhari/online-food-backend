using DataAccessLayer;

namespace FoodAppBackend.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> Login(string email, string password);
        Task<User> SignUp(User user);
        Task<User> TotalOrders(User user);

    }
}
