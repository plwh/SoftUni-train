using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        List<ITrafficLight> trafficLights = new List<ITrafficLight>();

        foreach (var light in input)
            trafficLights.Add(new TrafficLight(light));

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            trafficLights.ForEach(l => l.Cycle());

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}
