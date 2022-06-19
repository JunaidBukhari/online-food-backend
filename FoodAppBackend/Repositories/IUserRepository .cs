using DataAccessLayer;

namespace FoodAppBackend.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> Login(User user);
        Task<User> SignUp(User user);
        Task<User> TotalOrders(User user);

    }
}
