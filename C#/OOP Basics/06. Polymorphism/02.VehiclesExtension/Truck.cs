using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
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
        if (this.FuelQuantity + amount * 0.95 > this.TankCapacity)
        {
            throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
        }

        if (amount <= 0)
        {
            throw new InvalidOperationException("Fuel must be a positive number");
        }
        this.FuelQuantity += amount * 0.95;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"{this.GetType().Name}: {this.FuelQuantity:f2}");
    }
}
