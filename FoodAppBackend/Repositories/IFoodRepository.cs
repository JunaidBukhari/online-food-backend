using DataAccessLayer;

namespace FoodAppBackend.Repositories
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFood();
        Task<Food> AddFood(Food food);
        Task<Food> UpdateFood(Food food);
        Task<Food> RateFood(Food food);
        Task<Food> DeleteFood(int Id);

    }
}
