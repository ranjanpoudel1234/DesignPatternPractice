using Ranjan.DesignPattern.AbstractFactory.ConceptExample;
using System;
using Ranjan.DesignPattern.AbstractFactory.RealWorldExample;

namespace Ranjan.DesignPattern.AbstractFactory
{
    //https://www.dofactory.com/net/abstract-factory-design-pattern
    class Program
    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        public static void Main()
        {
            // Abstract factory #1
            //RunConceptExample();
            RunRealWorldExample();
            Console.ReadKey();

        }

        public static void RunConceptExample()
        {
            ConceptExample.AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2

           ConceptExample.AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            // Wait for user input

            Console.ReadKey();
        }

        public static void RunRealWorldExample()
        {
            ContinentFactory americanFactory = new AmericanFactory();
            var americanAnimalWorld = new AnimalWorld(americanFactory);
            americanAnimalWorld.DescribeAnimalBehavior();

            ContinentFactory asianFactory = new AsianFactory();
            var asianAnimalWorld = new AnimalWorld(asianFactory);
            asianAnimalWorld.DescribeAnimalBehavior();
        }
    }
}
