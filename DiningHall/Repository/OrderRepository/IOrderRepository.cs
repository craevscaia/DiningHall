using DiningHall.Models;
namespace DiningHall.Repository.OrderRepository;

public interface IOrderRepository
{
    IList<Order> GenerateOrder();
}