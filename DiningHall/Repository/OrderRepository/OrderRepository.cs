using DiningHall.Models;
using DiningHall.Repository.FoodRepository;

namespace DiningHall.Repository.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private IFoodRepository _foodRepository;

    public OrderRepository(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public IList<Order> GenerateOrder()
    {
        var orders = new List<Order>
        {
            new()
            {
                Id = 1,
                Priority = 1,
                FoodList = { 1, 2 },
                MaxWait = 20
            },
            new()
            {
                Id = 1,
                Priority = 1,
                FoodList = { 1, 2 },
                MaxWait = 20
            },
            new()
            {
                Id = 1,
                Priority = 1,
                FoodList = { 1, 2 },
                MaxWait = 20
            },
            new()
            {
                Id = 1,
                Priority = 1,
                FoodList = { 1, 2 },
                MaxWait = 20
            }
        };
        
        return orders;
    }
}