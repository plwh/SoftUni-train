using System;
using System.Collections.Generic;
using System.Text;

namespace P04_SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.DistanceTravelled = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double DistanceTravelled { get; set; }

        public void Drive(double distance)
        {
            if (distance * this.FuelConsumptionPerKm > this.FuelAmount)
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }

            this.FuelAmount -= distance * this.FuelConsumptionPerKm;
            this.DistanceTravelled += distance;
        }

        public override string ToString()
        {
            return string.Format($"{this.Model} {this.FuelAmount:f2} {this.DistanceTravelled}");
        }
    }
}
