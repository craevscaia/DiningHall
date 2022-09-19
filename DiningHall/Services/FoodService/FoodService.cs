using DiningHall.Models;
using DiningHall.Repository.FoodRepository;

namespace DiningHall.Services.FoodService;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public void GenerateFood()
    {
        _foodRepository.GenerateFood();
    }

    public IList<Food> GetFood()
    {
        return _foodRepository.GetFood();
    }

    public Food? GetFoodById(int id)
    {
        return _foodRepository.GetFoodById(id);
    }
}