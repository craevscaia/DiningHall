using DiningHall.Models;
using DiningHall.Repository.WaiterRepsoitory;

namespace DiningHall.Services.WaiterService;

public class WaiterService : IWaiterService
{
    private readonly IWaiterRepository _waiterRepository;

    public WaiterService(IWaiterRepository waiterRepository)
    {
        _waiterRepository = waiterRepository;
    }

    public void GenerateWaiters()
    {
        _waiterRepository.GenerateWaiter();
    }

    public IList<Waiter> GetWaiters()
    {
        return _waiterRepository.GetWaiter();
    }

    public Waiter? GetWaitersById(int id)
    {
        return _waiterRepository.GetWaiterById(id);
    }
}