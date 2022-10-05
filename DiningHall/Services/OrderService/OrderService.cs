using System.Collections.Concurrent;
using System.Net;
using System.Text;
using DiningHall.Helpers;
using DiningHall.Models;
using DiningHall.Repository.OrderRepository;
using DiningHall.Services.FoodService;
using DiningHall.Services.TableService;
using Newtonsoft.Json;

namespace DiningHall.Services.OrderService;

public class OrderService : IOrderService
{
    // Give an order to this method to send it in the kitchen
    private readonly IOrderRepository _orderRepository;
    private readonly ITableService _tableService;
    private readonly IFoodService _foodService;

    public OrderService(IOrderRepository orderRepository, IFoodService foodService, ITableService tableService)
    {
        _orderRepository = orderRepository;
        _foodService = foodService;
        _tableService = tableService;
    }

    public async Task GenerateOrder()
    {
        var table = await _tableService.GetTableByStatus(Status.Free);

        if (table != null)
        {
            var foodList = await _foodService.GenerateOrderFood();
            var order = new Order
            {
                Id = await IdGenerator.GenerateId(),
                TableId = table.Id,
                Priority = RandomGenerator.NumberGenerator(5),
                CreatedOnUtc = DateTime.UtcNow,
                OrderIsComplete = false,
                FoodList = foodList,
            };

            table.OrderId = order.Id;
            table.Status = Status.Busy;

            _orderRepository.InsertOrder(order);
            Console.WriteLine($"A order with id {order.Id} was generated", ConsoleColor.Green);
            var sleepingTime = RandomGenerator.NumberGenerator(10, 15);
            Console.WriteLine($"The next order in: {sleepingTime} seconds", ConsoleColor.Yellow);
            await SleepingGenerator.Delay(sleepingTime);
        }
        else
        {
            var sleep = RandomGenerator.NumberGenerator(10, 20);
            Console.WriteLine(
                $"There are no free tables now, you need to wait {sleep}",
                ConsoleColor.DarkRed);
            await SleepingGenerator.Delay(sleep);
        }
    }

    public async Task SendOrder(Order order)
    {
        try
        {
            var serializeObject = JsonConvert.SerializeObject(order);
            var data = new StringContent(serializeObject, Encoding.UTF8, "application/json");

            const string url = Setting.KitchenUrl;
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                Console.WriteLine($"The order with id {order.Id} was driven in the kitchen");
                order.Status = Status.InKitchen;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to send order {order.Id}", ConsoleColor.Red);
        }
    }

    public Task<ConcurrentBag<Order>> GetAllOrders()
    {
        return Task.FromResult(_orderRepository.GetAllOrders());
    }
    public Task<Order?> GetOrderByTableId(int id)
    {
        return _orderRepository.GetOrderByTableId(id);
    }
}