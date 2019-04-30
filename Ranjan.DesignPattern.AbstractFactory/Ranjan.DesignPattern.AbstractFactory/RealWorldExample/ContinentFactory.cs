using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
}
