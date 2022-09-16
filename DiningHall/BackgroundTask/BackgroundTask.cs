using DiningHall.DiningHall;
using DiningHall.Repository.OrderRepository;
using DiningHall.Repository.TableRepository;

namespace DiningHall.BackgroundTask;

public class BackgroundTask : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BackgroundTask(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Delay(5000); // freez the program for x time
        using var scope = _serviceScopeFactory.CreateScope();
        var diningHall = scope.ServiceProvider.GetRequiredService<IDiningHall>();
        diningHall.MaintainDiningHall(stoppingToken);

        return Task.CompletedTask;
    }
}