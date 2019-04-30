using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public class AsianFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Cow();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Tiger();
        }
    }
}
