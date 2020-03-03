using System;
using System.Collections.Generic;

namespace _10.CarSalesman
{
    class Program
    {
        static List<Engine> engines = new List<Engine>();
        static List<Car> cars = new List<Car>();

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = ParseEngine(engineInfo);

                engines.Add(currentEngine);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = ParseCar(carInfo);

                cars.Add(currentCar);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($@"{car.Model}:
  {car.Engine.Model}:
    Power: {car.Engine.Power}
    Displacement: {car.Engine.Displacement}
    Efficiency: {car.Engine.Efficiency}
  Weight: {car.Weight}
  Color: {car.Color}");
            }
        }

        private static Car ParseCar(string[] carInfo)
        {
            string model = carInfo[0];
            Engine engine = engines.Find(a => a.Model == carInfo[1]);
            string weight = "n/a";
            string color = "n/a";

            if (carInfo.Length == 4)
            {
                weight = carInfo[2];
                color = carInfo[3];
            }
            else if (carInfo.Length == 3)
            {
                bool IsWeight = int.TryParse(carInfo[2], out int number);
                if (IsWeight)
                {
                    weight = number.ToString();
                }
                else
                {
                    color = carInfo[2];
                }
            }

            Car car = new Car(model,engine,weight,color);
            return car;
        }

        private static Engine ParseEngine(string[] engineInfo)
        {
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                string displacement = "n/a";
                string efficiency = "n/a";

                if (engineInfo.Length == 4)
                {
                    displacement = engineInfo[2];
                    efficiency = engineInfo[3];
                }
                else if (engineInfo.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out int number);
                    if (isDisplacement)
                    {
                        displacement = number.ToString();
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                    }
                }

                Engine engine = new Engine(model,power,displacement,efficiency);
                return engine;
        }
    }
}
