using DiningHall.Models;
using DiningHall.Repository.TableRepository;
using DiningHall.Repository.WaiterRepsoitory;
using DiningHall.Services.OrderService;

namespace DiningHall.Services.WaiterService;

public class WaiterService : IWaiterService
{
    private readonly IWaiterRepository _waiterRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IOrderService _orderService;

    public WaiterService(IWaiterRepository waiterRepository, ITableRepository tableRepository, IOrderService orderService)
    {
        _waiterRepository = waiterRepository;
        _tableRepository = tableRepository;
        _orderService = orderService;
    }

    public void GenerateWaiters()
    {
        _waiterRepository.GenerateWaiter();
    }

    public IList<Waiter> GetWaiters()
    {
        return _waiterRepository.GetWaiter();
    }

    public Task<Waiter?> GetWaitersById(int id)
    {
        return _waiterRepository.GetWaiterById(id);
    }

    public Task<Waiter?> GetFreeWaiter()
    {
        return _waiterRepository.GetFreeWaiter();
    }

    //Sent http requests
    public async Task  ServTable()
    {
        var waiter = await GetFreeWaiter();
        var table = await _tableRepository.GetTableByStatus(Status.Busy);
        if (table != null && waiter != null)
        {
            var order = await _orderService.GetOrderByTableId(table.Id);
            if (order != null)
            {
                order.WaiterId = waiter.Id;

                waiter.IsFree = false;
                await _orderService.SendOrder(order);
                Console.WriteLine($"I am waiter {waiter.Id} and I sent order {order.Id} to kitchen");
                table.Status = Status.OrderTaken;
            }
        }
        
        
    }
}