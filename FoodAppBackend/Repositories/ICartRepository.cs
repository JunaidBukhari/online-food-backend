using DataAccessLayer;

namespace FoodAppBackend.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCart(int userId);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> DeleteCart(int id);

    }
}
