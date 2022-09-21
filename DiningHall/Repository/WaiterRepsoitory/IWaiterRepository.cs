using DiningHall.Models;

namespace DiningHall.Repository.WaiterRepsoitory;

public interface IWaiterRepository
{
    void GenerateWaiter();
    IList<Waiter> GetWaiter();
    Task<Waiter?> GetWaiterById(int id);
    Task<Waiter?> GetFreeWaiter();
}