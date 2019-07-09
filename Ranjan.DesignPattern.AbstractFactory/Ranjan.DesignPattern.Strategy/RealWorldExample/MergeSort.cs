using System;

namespace Ranjan.DesignPattern.Strategy.RealWorldExample
{
    public class MergeSort : ISortStrategy
    {
        public void Sort()
        {
           Console.WriteLine("Merge sort doing its job");
        }
    }
}
