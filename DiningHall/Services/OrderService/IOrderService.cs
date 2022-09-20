using DiningHall.Models;

namespace DiningHall.Services.OrderService;

public interface IOrderService
{
    void GenerateAndSendOrder();
    void SendOrder(Order order);
}