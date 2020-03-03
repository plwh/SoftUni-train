using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();

            Car car = new Car(double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));

            tokens = Console.ReadLine().Split();

            Truck truck = new Truck(double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));

            tokens = Console.ReadLine().Split();

            Bus bus = new Bus(double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split();

                try
                {
                    if (tokens[0] == "Drive")
                    {
                        double distance = double.Parse(tokens[2]);

                        if (tokens[1] == "Car")
                        {
                            car.Drive(distance);
                        }
                        else if (tokens[1] == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        else
                        {
                            bus.Drive(distance);
                        }
                    }
                    else if (tokens[0] == "DriveEmpty")
                    {
                        bus.DriveEmpty(double.Parse(tokens[2]));
                    }
                    else if (tokens[0] == "Refuel")
                    {
                        double amount = double.Parse(tokens[2]);

                        if (tokens[1] == "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (tokens[1] == "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            car.GetInfo();
            truck.GetInfo();
            bus.GetInfo();
        }
    }
}
