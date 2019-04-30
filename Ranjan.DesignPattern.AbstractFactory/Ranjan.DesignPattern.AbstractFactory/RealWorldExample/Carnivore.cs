using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public abstract class Carnivore
    {
        public abstract void Eats(Herbivore h);

        public abstract void EatsMeatALot();
    }
}
