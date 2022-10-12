using System.Net;
using System.Text;
using DiningHall.Models;
using DiningHall.Services.FoodService;
using Newtonsoft.Json;

namespace DiningHall.Services.RegisterRestaurantService;

public class RegisterRestaurantService : IRegisterRestaurantService
{
    private readonly IFoodService _foodService;

    public RegisterRestaurantService(IFoodService foodService)
    {
        _foodService = foodService;
    }

    //Send Restaurant info to FOS
    public async Task RegisterRestaurant()
    {
        try
        {
            var restaurantData =await GetRestaurantDetails();
            var serializeObject = JsonConvert.SerializeObject(restaurantData);
            var data = new StringContent(serializeObject, Encoding.UTF8, "application/json");

            const string url = Setting.FoodOrderingServiceRegisterUrl;
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                Console.WriteLine($"I was registered to Food Ordering Service ");
               
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong");
        }
    }

    private async Task<RestaurantData> GetRestaurantDetails()
    {
        return new RestaurantData
        {
            RestaurantId = 1,
            RestaurantName = "Restaurant1",
            FoodList = await _foodService.GetFood()
        };
    }
}