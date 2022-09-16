using DiningHall.Models;
namespace DiningHall.Repository.WaiterRepsoitory;

public class WaiterRepository : IWaiterRepository
{
    private readonly IList<Waiter> _waiters;

    public WaiterRepository()
    {
        _waiters = new List<Waiter>();
    }
    public void GenerateWaiter()
    {
        for (var id = 1; id <= 4; id++)
        {
            _waiters.Add(new Waiter()
            {
                Id = id,
                IsFree = true
            });
        }
    }
    
    public IList<Waiter> GetWaiter()
    {
        return _waiters;
    }

    public Waiter? GetWaiterById(int id)
    {
        return _waiters.FirstOrDefault(waiters => waiters.Id.Equals(id));
    }
    
}