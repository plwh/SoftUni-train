using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_RawData
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

                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo);

                for (int j = 0, k = 5; j < 4; j++, k += 2)
                {
                    double tirePressure = double.Parse(tokens[k]);
                    int tireAge = int.Parse(tokens[k + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    car.Tires.Add(tire);
                }

                cars.Add(car);
            }

            string searchedType = Console.ReadLine();

            switch (searchedType)
            {
                case "fragile":
                    cars
                        .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
                case "flammable":
                    cars
                        .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
            }
        }
    }
}
