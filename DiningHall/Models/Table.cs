namespace DiningHall.Models;

public class Table
{
    public int Id { get; set; }
    public Status Status { get; set; }
    public int OrderId { get; set; }
}