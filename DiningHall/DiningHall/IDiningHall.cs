namespace DiningHall.DiningHall;

public interface IDiningHall
{
    void InitializeDiningHall();
    void MaintainDiningHall(CancellationToken stoppingToken);
}