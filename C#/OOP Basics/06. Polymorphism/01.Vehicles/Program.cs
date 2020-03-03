using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            Car car = new Car(double.Parse(tokens[1]), double.Parse(tokens[2]));

            tokens = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(tokens[1]), double.Parse(tokens[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split();
               
                if (tokens[0] == "Drive")
                {
                    double distance = double.Parse(tokens[2]);

                    try
                    {
                        if (tokens[1] == "Car")
                        {
                            car.Drive(distance);
                        }
                        else
                        {
                            truck.Drive(distance);
                        };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (tokens[0] == "Refuel")
                {
                    double amount = double.Parse(tokens[2]);

                    if (tokens[1] == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    };
                }
            }

            car.GetInfo();
            truck.GetInfo();
        }
    }
}
