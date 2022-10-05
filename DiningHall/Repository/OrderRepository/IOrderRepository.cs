using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Repository.OrderRepository;

public interface IOrderRepository
{
    void InsertOrder(Order order);
    Task<Order?> GetOrderByTableId(int tableId);
    public ConcurrentBag<Order> GetAllOrders();
}