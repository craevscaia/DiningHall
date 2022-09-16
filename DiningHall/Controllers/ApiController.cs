using DiningHall.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiningHall.Controllers;

[ApiController]
[Route("/distribution")] 
public class ApiController : ControllerBase
{
    [HttpPost]  
    public void SendOrder([FromBody] Order order)
    {
        var finishedOrder = order;
    }
}