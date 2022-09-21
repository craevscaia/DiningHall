namespace DiningHall.Helpers;

public class IdGenerator
{
    private static int Id { get; set; }

    public static Task<int> GenerateId()
    {
        return Task.FromResult(Id += 1);
    }
}