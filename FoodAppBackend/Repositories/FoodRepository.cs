using DataAccessLayer;
using FoodAppBackend.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _Context;
        public FoodRepository(ApplicationDbContext Context)
        {
            _Context=Context;
        }
        public async Task<Food> AddFood(Food food)
        {
            var result=await _Context.Foods.AddAsync(food);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Food> DeleteFood(int Id)
        {
            var result = await _Context.Foods.FindAsync(Id);
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

        public async Task<IEnumerable<Food>> GetFood()
        {
            return await _Context.Foods.ToListAsync();
        }

        public async Task<Food> UpdateFood(Food food)
        {
       
                _Context.Foods.Update(food);
                await _Context.SaveChangesAsync();
                return food;
       
        }

    
    }
}
