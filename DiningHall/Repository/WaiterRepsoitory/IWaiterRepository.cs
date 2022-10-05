using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Repository.WaiterRepsoitory;

public interface IWaiterRepository
{
    void GenerateWaiter();
    ConcurrentBag<Waiter> GetWaiter();
    Task<Waiter?> GetWaiterById(int id);
    Task<Waiter?> GetFreeWaiter();
}