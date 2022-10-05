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
    
    //Return the object by id
    public Food? GetFoodById(int id)
    {
        return _foodRepository.GetFoodById(id);
    }
    
    public Task<IList<int>> GenerateOrderFood()
    {
        var random = new Random();
        var size = random.Next(5);
        var listOfFood = new List<int>();

        for (var id = 0; id < size; id++)
        {
            listOfFood.Add(random.Next(13));
        }

        return Task.FromResult<IList<int>>(listOfFood);
    }
}