using DiningHall.Models;

namespace DiningHall.Repository.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly IList<Order> _orders;

    public OrderRepository()
    {
        _orders = new List<Order>();
    }

    public void InsertOrder(Order order)
    {
        _orders.Add(order);
    }

    public Task<Order?> GetOrderByTableId(int tableId)
    {
        return Task.FromResult(_orders.FirstOrDefault(order => order.TableId.Equals(tableId)));
    }
}