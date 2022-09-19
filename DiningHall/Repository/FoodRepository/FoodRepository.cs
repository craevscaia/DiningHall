using DiningHall.Models;

namespace DiningHall.Repository.FoodRepository;

public class FoodRepository : IFoodRepository
{
    private readonly IList<Food> _menu;

    public FoodRepository()
    {
        _menu = new List<Food>();
    }

    public void GenerateFood()
    {
        _menu.Add(new Food
        {
            Id = 1,
            Name = "pizza",
            PreparationTime = 20,
            Complexity = 2,
            CookingApparatus = CookingApparatus.Oven
        });
        _menu.Add(new Food
        {
            Id = 2,
            Name = "salad",
            PreparationTime = 10,
            Complexity = 1,
            CookingApparatus = null
        });
        _menu.Add(new Food
        {
            Id = 3,
            Name = "zeama",
            PreparationTime = 7,
            Complexity = 1,
            CookingApparatus = CookingApparatus.Stove
        });
        _menu.Add(new Food
        {
            Id = 4,
            Name = "Scallop Sashimi with Meyer Lemon Confit",
            PreparationTime = 32,
            Complexity = 3,
            CookingApparatus = null
        });
        _menu.Add(new Food
        {
            Id = 5,
            Name = "Island Duck with Mulberry Mustard",
            PreparationTime = 35,
            Complexity = 3,
            CookingApparatus = CookingApparatus.Oven
        });
        _menu.Add(new Food
        {
            Id = 6,
            Name = "Waffles",
            PreparationTime = 10,
            Complexity = 1,
            CookingApparatus = CookingApparatus.Stove
        });
        _menu.Add(new Food
        {
            Id = 7,
            Name = "Aubergine",
            PreparationTime = 20,
            Complexity = 2,
            CookingApparatus = CookingApparatus.Oven
        });
        _menu.Add(new Food
        {
            Id = 8,
            Name = "Lasagna",
            PreparationTime = 30,
            Complexity = 2,
            CookingApparatus = CookingApparatus.Oven
        });
        _menu.Add(new Food
        {
            Id = 9,
            Name = "Burger",
            PreparationTime = 15,
            Complexity = 1,
            CookingApparatus = CookingApparatus.Stove
        });
        _menu.Add(new Food
        {
            Id = 10,
            Name = "Gyros",
            PreparationTime = 15,
            Complexity = 1,
            CookingApparatus = null
        });
        _menu.Add(new Food
        {
            Id = 11,
            Name = "Kebab",
            PreparationTime = 15,
            Complexity = 1,
            CookingApparatus = null
        });
        _menu.Add(new Food
        {
            Id = 12,
            Name = "Unagi Maki",
            PreparationTime = 20,
            Complexity = 2,
            CookingApparatus = null
        });
        _menu.Add(new Food
        {
            Id = 13,
            Name = "Tobacco Chicken",
            PreparationTime = 30,
            Complexity = 2,
            CookingApparatus = CookingApparatus.Oven 
        });
    }

    public IList<Food> GetFood()
    {
        return _menu;
    }

    public Food? GetFoodById(int id)
    {
        return _menu.FirstOrDefault(food => food.Id.Equals(id));
    }
}