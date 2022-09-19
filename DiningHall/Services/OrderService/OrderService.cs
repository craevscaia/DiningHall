using System.Text;
using DiningHall.Models;
using DiningHall.Repository.OrderRepository;
using DiningHall.Services.TableService;
using Newtonsoft.Json;

namespace DiningHall.Services.OrderService;

public class OrderService : IOrderService
{
    // Give an order to this method to send it in the kitchen
    private readonly IOrderRepository _orderRepository;
    private readonly ITableService _tableService;

    public OrderService(IOrderRepository orderRepository, ITableService tableService)
    {
        _orderRepository = orderRepository;
        _tableService = tableService;
    }

    public async void SendOrder(Order order)
    {
        try
        {
            var json = JsonConvert.SerializeObject(order); // convert to json
            var data = new StringContent(json, Encoding.UTF8, "application/json");  // convert to data
            var url = Setting.KitchenUrl;

            using var client = new HttpClient(); //open a portal 

            var response = await client.PostAsync(url, data); //send through portal my data
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to send order");
        }
    }

    public void AssignTableOrder()
    {
        var table = _tableService.GetFreeTable();
        if (table != null)
        {
           var orders = _orderRepository.GenerateOrder();
           foreach (var order in orders)
           {
               SendOrder(order);
           }

        }
    }
}