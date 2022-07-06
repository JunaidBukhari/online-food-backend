using FoodApp.DataContext;
using FoodApp.Interfaces;
using FoodApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Services
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _Context;

        /// <summary>
        /// Constructor used to get the DbContext
        /// </summary>
        /// <param name="Context">Application DB Context</param>
        public FoodRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        /// <summary>
        /// Method used to create the food item
        /// </summary>
        /// <param name="food">Data of Food</param>
        /// <returns>Food Object</returns>
        public async Task<Food> AddFood(Food food)
        {
            var result = await _Context.Foods.AddAsync(food);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Method used to Delete the food item with specific id
        /// </summary>
        /// <param name="Id">Deleted Food Item ID</param>
        /// <returns>Result of deleted Food Item</returns>
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

        /// <summary>
        /// Method used to get the list of all food items
        /// </summary>
        /// <returns>return list of food items</returns>
        public async Task<IEnumerable<Food>> GetFood()
        {
            return await _Context.Foods.ToListAsync();
        }

        public async Task<IEnumerable<Food>> RateFood(Food food)
        {

            var result = await _Context.Foods.Where(fod => fod.Id == food.Id).ToListAsync();
            var rating = ((result[0].Rating * result[0].NumberOfRatings) + food.Rating);
            result[0].NumberOfRatings++;
            rating = rating / result[0].NumberOfRatings;
            result[0].Rating = rating;
            _Context.Foods.Update(result[0]);
            await _Context.SaveChangesAsync();
            return result;


        }

        /// <summary>
        /// Method used to update the food object
        /// </summary>
        /// <param name="food">Food Data</param>
        /// <returns>Updated Food Object</returns>
        public async Task<Food> UpdateFood(Food food)
        {

            _Context.Foods.Update(food);
            await _Context.SaveChangesAsync();
            return food;

        }


    }
}
