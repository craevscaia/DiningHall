using DiningHall.Models;

namespace DiningHall.Services.FoodService;

public interface IFoodService
{
    public void GenerateFood();
    public Task<IList<Food>> GetFood();
    public Task<Food?> GetFoodById(int id);
    Task<IList<int>> GenerateOrderFood();
}