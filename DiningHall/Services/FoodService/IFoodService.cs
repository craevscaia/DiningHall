using DiningHall.Models;

namespace DiningHall.Services.FoodService;

public interface IFoodService
{
    public void GenerateFood();
    public IList<Food> GetFood();
    public Food? GetFoodById(int id);
}