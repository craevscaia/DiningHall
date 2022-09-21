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
    private readonly ITableService _tableService;
    private readonly IFoodService _foodService;
    private readonly IOrderRepository _orderRepository;

    public OrderService(ITableService tableService, IFoodService foodService, IOrderRepository orderRepository)
    {
        _tableService = tableService;
        _foodService = foodService;
        _orderRepository = orderRepository;
    }

    public async Task GenerateOrder()
    {
        var random = new Random();
        while (true)
        {
            var table = await _tableService.GetTableByStatus(Status.Free);

            if (table != null)
            {
                var foodList = await _foodService.GenerateOrderFood();
                var order = new Order
                {
                    Id = await IdGenerator.GenerateId(),
                    TableId = table.Id,
                    Priority = random.Next(3),
                    CreatedOnUtc = DateTime.UtcNow,
                    OrderIsComplete = false,
                    FoodList = foodList,
                };

                table.OrderId = order.Id;
                table.Status = Status.Busy;
                _orderRepository.InsertOrder(order);
                Console.WriteLine($"A order with id {order.Id} was generated");
                Console.WriteLine($"Next order in 10 sec");
                await Task.Delay(TimeSpan.FromSeconds(10)); // sleep this methode for 30 sec, we will generate an order every 30 sec
            }
            else
            {
                await Task.Delay(TimeSpan.FromSeconds(60));
            }

            break;
        }
    }

    public async Task SendOrder(Order order)
    {
        try
        {
            var json = JsonConvert.SerializeObject(order); // convert to json
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // convert to data
            var url = Setting.KitchenUrl;

            using var client = new HttpClient(); //open a portal 

            var response = await client.PostAsync(url, data); //send through portal my 
            if (response.IsSuccessStatusCode)
            {
                Console.Write($"A order with id {order.Id} was sent to kitchen");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to send order");
        }
    }

    public Task<Order?> GetOrderByTableId(int tableId)
    {
        return _orderRepository.GetOrderByTableId(tableId);
    }
}