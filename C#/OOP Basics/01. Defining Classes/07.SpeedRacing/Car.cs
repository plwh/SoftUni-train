using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    string model;
    double fuelAmount;
    double fuelConsumptionPerKm;
    double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.DistanceTraveled = 0;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; } 
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        set { fuelConsumptionPerKm = value; }
    }

    public double DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public bool CanMove(int amountOfKm)
    {
        return this.FuelAmount >= amountOfKm * this.FuelConsumptionPerKm;
    }
}
