using DiningHall.DiningHall;
namespace DiningHall.BackgroundTask;

public class BackgroundTask : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BackgroundTask(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await Task.Delay(5000, stoppingToken);
            using var scope = _serviceScopeFactory.CreateScope();
            var diningHall = scope.ServiceProvider.GetRequiredService<IDiningHall>();
            await diningHall.InitializeDiningHall(); //initialize dining hall method
            diningHall.MaintainDiningHall(stoppingToken);
        }
        catch (Exception)
        {
            // ignored
        }
        finally
        {
            if (!stoppingToken.IsCancellationRequested)
                Console.WriteLine("Programul a dorit sa se opreasca asa ca el s-a oprit");
        }
    }
}