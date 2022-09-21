using DiningHall.Models;

namespace DiningHall.Services.WaiterService;

public interface IWaiterService
{
    void GenerateWaiters();
    IList<Waiter> GetWaiters();
    Task<Waiter?> GetWaitersById(int id);
    Task<Waiter?> GetFreeWaiter();
    Task ServTable();
}