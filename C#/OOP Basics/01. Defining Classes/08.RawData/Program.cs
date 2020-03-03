using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split();

                string model = currentCarInfo[0];

                int engineSpeed = int.Parse(currentCarInfo[1]);
                int enginePower = int.Parse(currentCarInfo[2]);
                Engine currentEngine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(currentCarInfo[3]);
                string cargoType = currentCarInfo[4];
                Cargo currentCargo = new Cargo(cargoWeight, cargoType);

                Car currentCar = new Car(model, currentEngine, currentCargo);

                for (int j = 0, k = 5; j < 4; j++, k += 2)
                {
                    double currTirePressure = double.Parse(currentCarInfo[k]);
                    int currTireAge = int.Parse(currentCarInfo[k + 1]);

                    Tire currentTire = new Tire(currTirePressure, currTireAge);

                    currentCar.Tires.Add(currentTire);
                }

                cars.Add(currentCar);
            }

            string command = Console.ReadLine();

            if (command == "flamable")
            {
                cars
                    .Where(a => (a.Cargo.CargoType == "flamable") && (a.Engine.EnginePower > 250))
                    .ToList()
                    .ForEach(a => Console.WriteLine(a.Model));
            }
            else
            {
                cars
                   .Where(a => (a.Cargo.CargoType == "fragile") && (a.Tires.Any(t => t.TirePressure < 1)))
                   .ToList()
                   .ForEach(a => Console.WriteLine(a.Model));
            }
        }
    }
}
