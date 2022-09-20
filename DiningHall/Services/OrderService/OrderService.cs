using System.Text;
using DiningHall.Helpers;
using DiningHall.Models;
using DiningHall.Services.FoodService;
using DiningHall.Services.TableService;
using Newtonsoft.Json;

namespace DiningHall.Services.OrderService;

public class OrderService : IOrderService
{
    // Give an order to this method to send it in the kitchen
    private readonly ITableService _tableService;
    private readonly IFoodService _foodService;

    public OrderService(ITableService tableService, IFoodService foodService)
    {
        _tableService = tableService;
        _foodService = foodService;
    }

    public void GenerateAndSendOrder()
    {
        var random = new Random();
        while (true)
        {
            var table = _tableService.GetTableByStatus(Status.Free);

            if (table != null)
            {
                var foodList = _foodService.GenerateOrderFood();
                var order = new Order
                {
                    Id = IdGenerator.GenerateId(),
                    TableId = table.Id,
                    Priority = random.Next(3),
                    CreatedOnUtc = DateTime.UtcNow,
                    OrderIsComplete = false,
                    FoodList = foodList,
                };

                table.OrderId = order.Id;
                SendOrder(order);
                Console.Write($"A order with id {order.Id} was generated");
                Thread.Sleep(TimeSpan.FromSeconds(30)); // sleep this methode for 30 sec, we will generate an order every 30 sec
            }
            else
            {
                Thread.Sleep(5000);
            }

            break;
        }
    }

    public async void SendOrder(Order order)
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
}