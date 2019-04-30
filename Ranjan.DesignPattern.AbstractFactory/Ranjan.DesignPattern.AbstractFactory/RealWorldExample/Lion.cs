using System;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public class Lion : Carnivore
    {
        public override void Eats(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name +
                              " eats " + h.GetType().Name);
        }

        public override void EatsMeatALot()
        {
            Console.WriteLine(this.GetType().Name + "eat meat a lot that LIONS in general love.");
        }
    }
}
