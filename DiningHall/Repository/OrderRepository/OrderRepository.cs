using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Repository.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly ConcurrentBag<Order> _orders;

    public OrderRepository()
    {
        _orders = new ConcurrentBag<Order>();
    }

    public void InsertOrder(Order order)
    {
        _orders.Add(order);
    }

    public ConcurrentBag<Order> GetAllOrders()
    {
        return _orders;
    }
    public Task<Order?> GetOrderByTableId(int tableId)
    {
        return Task.FromResult(_orders.FirstOrDefault(order => order.TableId.Equals(tableId)));
    }
}