using System;

class Vehicle
{
    string Name;
    int PassengerCapacity;
    string Color;
    bool HasEngine;
    int Odometer = 0;
    public Vehicle(string name, int passengerCapacity,string color, bool hasEngine)
    {
        
        Name = name;
        PassengerCapacity = passengerCapacity;
        Color = color;
        HasEngine = hasEngine;
    }
    public Vehicle(string name, string color)
    {
        Name = name;
        PassengerCapacity = 5;
        Color = color;
        HasEngine = true;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Your {Color} {PassengerCapacity} seater {Name} has travelled {Odometer}");
    }
    public void Trip(int trip)
    {
        Odometer += trip;
    }
}