using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle
{
    private double fuelQuantity;
    protected double fuelConsumptionPerKm;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.fuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        protected set { fuelQuantity = value; }
    }

    public abstract void Drive(double distance);
    public abstract void Refuel(double amount);
    public abstract void GetInfo();
}
