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

    public void InitializeDiningHall()
    {
        Parallel.Invoke(
            () => _tableService.GenerateTables(),
            () => _waiterService.GenerateWaiters(),
            () => _foodService.GenerateFood()
        );
        Task.WaitAll();
    }

    public void MaintainDiningHall(CancellationToken stoppingToken)
    {
        InitializeDiningHall();

        while (!stoppingToken.IsCancellationRequested)
        {
            _orderService.AssignTableOrder();
        }
    }
}