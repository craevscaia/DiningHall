using DiningHall.Models;

namespace DiningHall.Repository.WaiterRepsoitory;

public interface IWaiterRepository
{
    void GenerateWaiter();
    IList<Waiter> GetWaiter();
    Waiter? GetWaiterById(int id);
}