using DiningHall.Models;

namespace DiningHall.Services.OrderService;

public interface IOrderService
{
    Task GenerateOrder();
    Task SendOrder(Order order);
    Task<Order?> GetOrderByTableId(int tableId);
}