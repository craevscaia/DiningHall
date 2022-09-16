namespace DiningHall.Models;

public class Waiter
{
    public int Id { get; set; }
    public int TableId { get; set; }
    public bool IsFree { get; set; }
}