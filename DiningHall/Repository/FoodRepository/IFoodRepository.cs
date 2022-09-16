using DiningHall.Models;

namespace DiningHall.Repository.FoodRepository;

public interface IFoodRepository
{
    public void GenerateFood();
    public IList<Food> GetFood();
    public Food? GetFoodById(int id);
}