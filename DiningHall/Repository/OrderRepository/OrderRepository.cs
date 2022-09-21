using DiningHall.Models;

namespace DiningHall.Repository.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private IList<Order> _orders;

    public OrderRepository(IList<Order> orders)
    {
        _orders = orders;
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