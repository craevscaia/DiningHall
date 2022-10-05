using System.Collections.Concurrent;
using DiningHall.Models;
namespace DiningHall.Repository.WaiterRepsoitory;

public class WaiterRepository : IWaiterRepository
{
    private readonly ConcurrentBag<Waiter> _waiters;

    public WaiterRepository()
    {
        _waiters = new ConcurrentBag<Waiter>();
    }
    public void GenerateWaiter()
    {
        for (var id = 1; id <= 4; id++)
        {
            _waiters.Add(new Waiter()
            {
                Id = id,
                IsFree = true,
                ActiveOrders = new List<Order>()
            });
        }
    }
    
    public Task<ConcurrentBag<Waiter>> GetWaiter()
    {
        return Task.FromResult(_waiters);
    }

    public Task<Waiter?> GetWaiterById(int id)
    {
        return Task.FromResult(_waiters.FirstOrDefault(waiters => waiters.Id.Equals(id)));
    }

    public Task<Waiter?> GetFreeWaiter()
    {
        return Task.FromResult(_waiters.FirstOrDefault(waiter => waiter.IsFree));
    }
}