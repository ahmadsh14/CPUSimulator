using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = readFromFile<Simulation>.LoadTasksJSON("./readTasks.json");
            var dataXML = readFromFile<Simulation>.LoadTasksXML("./ReadTaskXML.xml");

            Console.WriteLine($"Num Of Processors: {data.ProcessorsCount}");
            var simulator = new Simulation(data.ProcessorsCount, data.Tasks);
            simulator.RunSimulation();
        }
    }
}

