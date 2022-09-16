using DiningHall.Models;

namespace DiningHall.Repository.OrderRepository;

public class OrderRepository : IOrderRepository
{
    public Order GenerateOrder()
    {
        return new Order()
        {
            Id = 1,
            Priority = 1,
            FoodList = new List<int>(),
            MaxWait = 20
        };
      
    }
}