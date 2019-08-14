using System;

namespace Ranjan.DesignPattern.Decorator.RealWorldExample
{
    public class Hireable : VehicleDecoratorBase
    {
        public Hireable(VehicleBase vehicle) : base(vehicle) { }

        public void Hire(string name)
        {
            Console.WriteLine("{0} {1} hired by {2} at a price of {3:c} for {4} laps."
                , Make, Model, name, HirePrice, HireLaps);
        }
    }
}
