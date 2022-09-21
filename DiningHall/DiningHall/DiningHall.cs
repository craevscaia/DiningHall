using DiningHall.Services.FoodService;
using DiningHall.Services.OrderService;
using DiningHall.Services.TableService;
using DiningHall.Services.WaiterService;

namespace DiningHall.DiningHall;

public class DiningHall : IDiningHall
{
    private static IOrderService _orderService;
    private readonly ITableService _tableService;
    private static IWaiterService _waiterService;
    private readonly IFoodService _foodService;

    public DiningHall(IOrderService orderService, ITableService tableService, IWaiterService waiterService,
        IFoodService foodService)
    {
        _orderService = orderService;
        _tableService = tableService;
        _waiterService = waiterService;
        _foodService = foodService;
    }
    
    //This will run in parallel three method that generate tables, waiters and food
    
    public async Task InitializeDiningHall()
    {
        var taskList = new List<Task>
        {
            Task.Run(() => _foodService.GenerateFood()),
            Task.Run(() => _waiterService.GenerateWaiters()),
            Task.Run(() => _tableService.GenerateTables())
        };

        await Task.WhenAll(taskList);
    }
    
    public Task MaintainDiningHall(CancellationToken stoppingToken)
    {
        var generateOrderThread1 = CreateThread(stoppingToken);
        var generateOrderThread2 = CreateThread(stoppingToken);
        var generateOrderThread3 = CreateThread(stoppingToken);
        var generateOrderThread4 = CreateThread(stoppingToken);
        generateOrderThread1.Start();
        generateOrderThread2.Start();
        generateOrderThread3.Start();
        generateOrderThread4.Start();

        return Task.CompletedTask;
    }



    private static async Task CreateThread(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _orderService.GenerateOrder();
            await _waiterService.ServTable();
        }
    }

}