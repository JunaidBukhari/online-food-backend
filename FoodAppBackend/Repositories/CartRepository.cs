using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _Context;

        /// <summary>
        /// Constructor to get the cart Context
        /// </summary>
        /// <param name="Context">DB Context</param>
        public CartRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        /// <summary>
        /// Method used to update the cart object
        /// </summary>
        /// <param name="cart">Cart Data</param>
        /// <returns>None</returns>
        public async Task<Cart> UpdateCart(Cart cart)
        {
            if (cart.Id > 0)
            {
                if (cart.Item < 1)
                {
                    _Context.Remove(cart);
                    await _Context.SaveChangesAsync();
                    return cart;
                }
                _Context.Cart.Update(cart);
                await _Context.SaveChangesAsync();
                return null;

            }
            else
            {
                await _Context.Cart.AddAsync(cart);
                await _Context.SaveChangesAsync();
                return null;

            }
        }

        /// <summary>
        /// Method used to get the specific cart object
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of Cart against specific user id</returns>
        public async Task<IEnumerable<Cart>> GetCart(int userId)
        {
            var result = await _Context.Cart.Where(cart => cart.UserId == userId).ToListAsync();

            if (result != null)
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Method used to delete the cart item
        /// </summary>
        /// <param name="id">Cart ID</param>
        /// <returns>Delete item result</returns>
        public async Task<Cart> DeleteCart(int id)
        {
            var result = await _Context.Cart.FindAsync(id);
            if (result != null)
            {
                _Context.Remove(result);
                await _Context.SaveChangesAsync();
                return result;

            }
            else
            {
                return null;
            }
        }
    }
}
