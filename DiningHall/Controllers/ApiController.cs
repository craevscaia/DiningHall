using DiningHall.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiningHall.Controllers;

//Controller is meant to return order
[ApiController]
[Route("/distribution")] 
public class ApiController : ControllerBase
{
    [HttpPost]  
    public void SendOrder([FromBody] Order order)
    {
        var finishedOrder = order;
        Console.WriteLine($"I have recieved order with id: {finishedOrder.Id} back");
    }
}