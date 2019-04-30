using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public class AmericanFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
}
