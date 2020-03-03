using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
        this.fuelConsumptionPerKm += 0.9;
    }

    public override void Drive(double distance)
    {
        double fuelNeeded = distance * this.fuelConsumptionPerKm;
        if (fuelNeeded > this.FuelQuantity)
        {
            throw new InvalidOperationException("Car needs refueling");
        }
        else
        {
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public override void Refuel(double amount)
    {
        if (this.FuelQuantity + amount > this.TankCapacity)
        {
            throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
        }

        if (amount <= 0)
        {
            throw new InvalidOperationException("Fuel must be a positive number");
        }
        this.FuelQuantity += amount;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"{this.GetType().Name}: {this.FuelQuantity:f2}");
    }
}
