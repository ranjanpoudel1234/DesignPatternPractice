using System;
using Ranjan.DesignPattern.Strategy.ConceptExample;
using Ranjan.DesignPattern.Strategy.RealWorldExample;

namespace Ranjan.DesignPattern.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //RunConceptExample();
            RunRealWorldExample();
        }

        public static void RunConceptExample()
        {
            Context context;

            // Three contexts following different strategies

            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user

            Console.ReadKey();
        }

        public static void RunRealWorldExample()
        {
            Sort sort;

            sort = new Sort(new MergeSort());
            sort.PerformSort();

            sort = new Sort(new BubbleSort());
            sort.PerformSort();

            Console.ReadKey();
        }
    }
}
