using FoodApp.Model;

namespace FoodApp.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCart(int userId);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> DeleteCart(int id);

    }
}
