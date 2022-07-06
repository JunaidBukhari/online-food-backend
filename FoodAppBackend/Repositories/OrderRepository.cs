using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _Context;

        /// <summary>
        /// Constructor used to get the applicataion DBContext
        /// </summary>
        /// <param name="Context">ApplicationDBContext</param>
        public OrderRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        /// <summary>
        /// Method used to get list of orders
        /// </summary>
        /// <returns>List of orders</returns>
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var result = await _Context.Order.ToListAsync();

            if (result != null)
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Method used to Update the order
        /// </summary>
        /// <param name="order">Order Data</param>
        /// <returns>None</returns>
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

        /// <summary>
        /// Method used to delete the specific order
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns>Delete order result</returns>
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

        /// <summary>
        /// Method used to get list of orders against specific user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>List of Order</returns>
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
