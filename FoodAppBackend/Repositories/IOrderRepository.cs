using DataAccessLayer;

namespace FoodAppBackend.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetMyOrders(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> UpdateOrder(Order order);
        Task<Order> DeleteOrder(int id);

    }
}
