using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Builder.RealWorldExample
{
    public class Vehicle
    {
        public string Name { get; set; }
        public string NumberOfTires { get; set; }
        public string Frame { get; set; }
        public EngineType EngineType { get; set; }


        public void ShowVehicle()
        {
            Console.WriteLine("Vehicle Made:" + Name);
            Console.WriteLine("NumberOfTires:" + NumberOfTires);
            Console.WriteLine("Frame:" + Frame);
            Console.WriteLine("EngineType:" + EngineType.ToString());
        }

        private Dictionary<string, string> _parts =
            new Dictionary<string, string>();

        // Constructor

        public Vehicle(string vehicleName)
        {
            this.Name = vehicleName;
        }

        // Indexer

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
    }
}
