using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _Context;

        public OrderRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var result = await _Context.Order.ToListAsync();

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            {
                if (order.Id > 0)
                {

                    _Context.Order.Update(order);
                    await _Context.SaveChangesAsync();
                    return null;

                }
                else
                {
                    await _Context.Order.AddAsync(order);
                    await _Context.SaveChangesAsync();
                    return null;

                }
            }
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var result = await _Context.Order.FindAsync(id);
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

        public async Task<IEnumerable<Order>> GetMyOrders(int id)
        {
            var result = await _Context.Order.Where(order => order.UserId == id).ToListAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }

     
    }
    
}
