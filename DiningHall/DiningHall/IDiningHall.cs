namespace DiningHall.DiningHall;

public interface IDiningHall
{
    Task InitializeDiningHall();
    void MaintainDiningHall(CancellationToken stoppingToken);
}