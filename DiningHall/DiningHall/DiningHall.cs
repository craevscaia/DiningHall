using DiningHall.Repository.OrderRepository;
using DiningHall.Services.OrderService;
using DiningHall.Services.TableService;

namespace DiningHall.DiningHall;

public class DiningHall : IDiningHall
{
    private readonly IOrderService _orderService;
    private readonly IOrderRepository _orderRepository;
    private readonly ITableService _tableService;

    public DiningHall(IOrderRepository orderRepository, IOrderService orderService, ITableService tableService)
    {
        _orderRepository = orderRepository;
        _orderService = orderService;
        _tableService = tableService;
    }

    public void InitializeDiningHall()
    {
        _tableService.GenerateTables();
    }

    public void MaintainDiningHall(CancellationToken stoppingToken)
    {
        InitializeDiningHall();

        while (!stoppingToken.IsCancellationRequested)
        {
            _orderService.AssignTableOrder();
            Thread.Sleep(7000);
        }
        
    }
}