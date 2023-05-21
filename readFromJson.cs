using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment1
{
    public class readFromFile<T>
    {
        public static T LoadTasks(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error loading tasks from {filePath}: {err.Message}");
                return default;

            }
        }
    }
}