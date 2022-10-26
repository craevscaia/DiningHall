namespace DiningHall.Models;

public static class Setting
{
    // public const string KitchenUrl = "http://host.docker.internal:7166/kitchen";
    //docker build -t dininghall .
    //docker run --name dininghall-container -p 7065:80 dininghall
    
    public const string KitchenUrl = "https://localhost:7166/kitchen";
    public const string FoodOrderingServiceRegisterUrl = "https://localhost:7143/register";
    // public const string FoodOrderingServiceRegisterUrl = "http://host.docker.internal:7143/register";
}