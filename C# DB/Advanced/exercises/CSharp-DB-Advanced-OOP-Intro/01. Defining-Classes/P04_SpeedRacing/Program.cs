using System;
using System.Collections.Generic;

namespace P04_SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string model = tokens[0];
                int fuelAmount = int.Parse(tokens[1]);
                double fuelConsumptionPerKm = double.Parse(tokens[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKm));
            }

            string input = "";


            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string carModel = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car car = cars.Find(c => c.Model == carModel);

                try
                {
                    car.Drive(amountOfKm);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            cars.ForEach(c => Console.WriteLine(c));
        }
    }
}
