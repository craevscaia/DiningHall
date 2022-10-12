using DiningHall.Helpers;
using DiningHall.Models;
using DiningHall.Repository.TableRepository;
using DiningHall.Services.TableService;
using DiningHall.Services.WaiterService;
using Microsoft.AspNetCore.Mvc;

namespace DiningHall.Controllers;

//Controller is meant to return order
[ApiController]
[Route("/distribution")]
public class ApiController : ControllerBase
{
    private readonly ITableService _tableService;
    private readonly IWaiterService _waiterService;
    private readonly Semaphore _semaphore;

    public ApiController(ITableService tableService, IWaiterService waiterService)
    {
        _tableService = tableService;
        _waiterService = waiterService;
        _semaphore = new Semaphore(1, 1);
    }

    [HttpPost]
    public async Task GetOrder([FromBody] Order order)
    {
        order.Status = Status.Served;
        var table = await _tableService.GetTableById(order.TableId);
        if (table != null)
        {
            table.Status = Status.Free;
            Console.WriteLine($"I received from the kitchen an order with id {order.Id} fo  r table {order.TableId}",
                ConsoleColor.Cyan);
            _semaphore.WaitOne();
            RatingHelper.GetRating(order);
            _semaphore.Release();
        }
    }
}