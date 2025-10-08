using System;
using System.Collections.Generic;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public Car(string make, string model, int year, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model} - ${Price}";
    }
}

public class CarOperation
{
    public Car? MostExpensiveCar(List<Car> cars)
    {
        return cars.OrderByDescending(c => c.Price).FirstOrDefault();
    }
    public Car? MostCheapestCar(List<Car> cars)
    {
        return cars.OrderBy(c => c.Price).FirstOrDefault();
    }

    public decimal MostAverageCarPrice(List<Car> cars)
    {
        return cars.Any() ? cars.Average(c => c.Price) : 0;
    }

    public Dictionary<string, Car?> MostExpensiveCarByEachBrand(List<Car> cars)
    {
        var mostExpensiveCarsByBrand = cars
        .GroupBy(c => c.Make)
        .ToDictionary(g => g.Key, g => g.OrderByDescending(c => c.Price)
        .FirstOrDefault());

        // Sort by brand
        return mostExpensiveCarsByBrand
              .OrderBy(pair => pair.Key)
              .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}