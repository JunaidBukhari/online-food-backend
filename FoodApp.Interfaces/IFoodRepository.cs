using FoodApp.Model;

namespace FoodApp.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFood();
        Task<Food> AddFood(Food food);
        Task<Food> UpdateFood(Food food);
        Task<IEnumerable<Food>> RateFood(Food food);
        Task<Food> DeleteFood(int Id);

    }
}
