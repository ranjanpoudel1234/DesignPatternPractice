using System;
using System.Collections.Generic;

namespace Ranjan.DesignPattern.Strategy.RealWorldExample
{
    public class BubbleSort : ISortStrategy
    {
        public void Sort()
        {     
            Console.WriteLine("Bubble sort doing its job");
        }
    }
}
