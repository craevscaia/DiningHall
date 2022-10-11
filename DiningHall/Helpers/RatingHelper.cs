﻿using DiningHall.Models;

namespace DiningHall.Helpers;

public static class RatingHelper
{
    private static readonly List<int> Rating = new();

    public static void GetRating(Order order)
    {
        var servedTime = Math.Abs(order.FinishedOnUtc.Subtract(order.CreatedOnUtc).TotalSeconds);

        if (servedTime < order.MaxWait)
        {
            Rating.Add(5);
        }
        else if (servedTime < order.MaxWait * 1.1)
        {
            Rating.Add(4);
        }
        else if (servedTime < order.MaxWait * 1.2)
        {
            Rating.Add(3);
        }
        else if (servedTime < order.MaxWait * 1.3)
        {
            Rating.Add(2);
        }
        else if (servedTime < order.MaxWait * 1.4)
        {
            Rating.Add(1);
        }

        Task.Delay(2000);
        Console.WriteLine($"Order with Id: {order.Id} was expected in {order.MaxWait} but come in {servedTime}");
        Console.WriteLine($"Rating for {Rating.Count} is : {Rating.Sum() / Rating.Count}");
    }
}