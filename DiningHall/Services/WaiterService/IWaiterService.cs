using DiningHall.Models;

namespace DiningHall.Services.WaiterService;

public interface IWaiterService
{
    void GenerateWaiters();
    IList<Waiter> GetWaiters();
    Waiter? GetWaitersById(int id);
}