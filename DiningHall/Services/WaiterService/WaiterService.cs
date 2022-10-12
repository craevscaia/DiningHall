using System.Collections.Concurrent;
using DiningHall.Helpers;
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
    private readonly Semaphore _semaphore;

    public WaiterService(IWaiterRepository waiterRepository, ITableRepository tableRepository,
        IOrderService orderService)
    {
        _waiterRepository = waiterRepository;
        _tableRepository = tableRepository;
        _orderService = orderService;
        _semaphore = new Semaphore(1, 1);
    }

    public void GenerateWaiters()
    {
        _waiterRepository.GenerateWaiter();
    }

    public Task<ConcurrentBag<Waiter>> GetWaiters()
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
    public async Task ServTable()
    {
        var waiter = await GetFreeWaiter();

        if (waiter != null)
        {
            var table = await _tableRepository.GetTableByStatus(Status.Busy);

            if (table != null)
            {
                var order = await _orderService.GetOrderByTableId(table.Id);
                if (order != null)
                {
                    order.WaiterId = waiter.Id;
                    order.CreatedOnUtc = DateTime.Now;
                    
                    waiter.Order = order;
                    waiter.IsFree = false;
                    waiter.ActiveOrders.Add(order);

                    Console.WriteLine(
                        $"I am {waiter.Id} and I drive order {order.Id} in the kitchen from table {table.Id}",
                        ConsoleColor.Blue);
                    await _orderService.SendOrder(order);

                    table.Status = Status.OrderTaken;
                    await SleepWaiter(waiter);
                }
            }
            else
            {
                var sleepTime = RandomGenerator.NumberGenerator(10);
                await SleepingGenerator.Delay(sleepTime);
            }
        }
        else
        {
            var sleepTime = RandomGenerator.NumberGenerator(2, 10);
            Console.WriteLine("There are no free waiters now");
            await SleepingGenerator.Delay(sleepTime);
        }
    }

    public Task<Waiter> GetWaiterByTableId(int orderTableId)
    {
        return _waiterRepository.GetWaiterByTableId(orderTableId);
    }

    private static async Task SleepWaiter(Waiter waiter)
    {
        var sleepTime = RandomGenerator.NumberGenerator(20, 40);
        Console.WriteLine($"I am waiter {waiter.Id}. I will rest for {sleepTime} seconds", ConsoleColor.Yellow);
        await SleepingGenerator.Delay(sleepTime);
        Console.WriteLine($"{waiter.Id} is ready for a new order", ConsoleColor.Green);
        waiter.IsFree = true;
    }
}