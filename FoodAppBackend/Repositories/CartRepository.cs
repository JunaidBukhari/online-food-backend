using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class CartRepository:ICartRepository
    {
        private readonly ApplicationDbContext _Context;

        public CartRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

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

        public async Task<IEnumerable<Cart>> GetCart(int userId)
        {
            var result =await _Context.Cart.Where(cart => cart.UserId == userId).ToListAsync(); 

            if (result != null)
            {
                return result;
            }
            return null;
        }

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
