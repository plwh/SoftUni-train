using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKm = double.Parse(carInfo[2]);

                Car currentCar = new Car(model,fuelAmount,fuelConsumptionPerKm);

                cars.Add(currentCar);
            }

            string line = "";

            while ((line = Console.ReadLine()) != "End")
            {
                string[] commands = line.Split();

                string carModel = commands[1];
                int amountOfKm = int.Parse(commands[2]);

                Car currentCar = cars.First(c => c.Model == carModel);

                if (currentCar.CanMove(amountOfKm))
                {
                    double usedFuel = amountOfKm * currentCar.FuelConsumptionPerKm;

                    currentCar.FuelAmount -= usedFuel;
                    currentCar.DistanceTraveled += amountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
}
