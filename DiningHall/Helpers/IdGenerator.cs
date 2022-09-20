namespace DiningHall.Helpers;

public class IdGenerator
{
    private static int Id { get; set; }

    public static int GenerateId()
    {
        return Id += 1;
    }
}