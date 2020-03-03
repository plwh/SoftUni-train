using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
        this.fuelConsumptionPerKm += 1.6;
    }

    public override void Drive(double distance)
    {
        double fuelNeeded = distance * this.fuelConsumptionPerKm;
        if (fuelNeeded > this.FuelQuantity)
        {
            throw new InvalidOperationException("Truck needs refueling");
        }
        else
        {
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public override void Refuel(double amount)
    {
        this.FuelQuantity += amount * 0.95;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"{this.GetType().Name}: {this.FuelQuantity:f2}");
    }
}
