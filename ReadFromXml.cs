using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment1
{

    public class ReadFromFileXML<T>
    {
        public static T LoadTasksXML(string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                // Access the root element
                XmlElement root = xmlDoc.DocumentElement;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error loading tasks from {filePath}: {err.Message}");
                return default;
            }
        }
    }

}

