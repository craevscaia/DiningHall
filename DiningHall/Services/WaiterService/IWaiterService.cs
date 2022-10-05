using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Services.WaiterService;

public interface IWaiterService
{   
    void GenerateWaiters();
    ConcurrentBag<Waiter> GetWaiters();
    Task<Waiter?> GetWaitersById(int id);
    Task<Waiter?> GetFreeWaiter();
    Task ServTable();
}