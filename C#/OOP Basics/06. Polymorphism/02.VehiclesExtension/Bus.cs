using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    { }

    public override void Drive(double distance)
    {
        double fuelNeeded = distance * (this.fuelConsumptionPerKm + 1.4);
        if (fuelNeeded > this.FuelQuantity)
        {
            throw new InvalidOperationException("Bus needs refueling");
        }
        else
        {
            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }

    public void DriveEmpty(double distance)
    {
        double fuelNeeded = distance * this.fuelConsumptionPerKm;
        if (fuelNeeded > this.FuelQuantity)
        {
            throw new InvalidOperationException("Bus needs refueling");
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
