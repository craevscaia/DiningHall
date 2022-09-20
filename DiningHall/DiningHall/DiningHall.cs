using DiningHall.Services.FoodService;
using DiningHall.Services.OrderService;
using DiningHall.Services.TableService;
using DiningHall.Services.WaiterService;

namespace DiningHall.DiningHall;

public class DiningHall : IDiningHall
{
    private readonly IOrderService _orderService;
    private readonly ITableService _tableService;
    private readonly IWaiterService _waiterService;
    private readonly IFoodService _foodService;

    public DiningHall(IOrderService orderService, ITableService tableService, IWaiterService waiterService,
        IFoodService foodService)
    {
        _orderService = orderService;
        _tableService = tableService;
        _waiterService = waiterService;
        _foodService = foodService;
    }
    
    //This will run in paraele three method that generate tables, waiters and food
    
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


    public void MaintainDiningHall(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _orderService.GenerateAndSendOrder();
        }
    }

}