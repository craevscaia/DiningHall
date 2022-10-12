using DiningHall.Models;

namespace DiningHall.Repository.FoodRepository;

public interface IFoodRepository
{
    public void GenerateFood();
    public Task<IList<Food>> GetFood();
    public Food? GetFoodById(int id);
}