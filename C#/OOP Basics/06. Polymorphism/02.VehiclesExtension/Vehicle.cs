using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle
{
    private double fuelQuantity;
    protected double fuelConsumptionPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.fuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TankCapacity = tankCapacity;
        if (fuelQuantity > tankCapacity)
        {
            this.FuelQuantity = 0;
        }
        else
        {
            this.FuelQuantity = fuelQuantity;
        }
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        protected set { fuelQuantity = value; }
    }

    public double TankCapacity
    {
        get { return tankCapacity; }
        protected set { tankCapacity = value; }
    }

    public abstract void Drive(double distance);
    public abstract void Refuel(double amount);
    public abstract void GetInfo();
}
