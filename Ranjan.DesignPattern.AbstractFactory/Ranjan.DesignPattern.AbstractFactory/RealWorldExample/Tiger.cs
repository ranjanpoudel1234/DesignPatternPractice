using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public class Tiger : Carnivore
    {
        public override void Eats(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name +
                              " eats " + h.GetType().Name);
        }

        public override void EatsMeatALot()
        {
            Console.WriteLine(this.GetType().Name + "eats meat a lot by tiger meat");
        }
    }
}
