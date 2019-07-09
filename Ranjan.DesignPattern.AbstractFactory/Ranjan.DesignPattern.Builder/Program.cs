using System;
using Ranjan.DesignPattern.Builder.ConceptExample;
using Ranjan.DesignPattern.Builder.RealWorldExample;

namespace Ranjan.DesignPattern.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunConceptExample();
            RunRealWorldExample();
        }

        public static void RunConceptExample()
        {
            // Create director and builders

            Director director = new Director();

            ConceptExample.Builder b1 = new ConcreteBuilder1();
            ConceptExample.Builder b2 = new ConcreteBuilder2();

            // Construct two products

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            // Wait for user

            Console.ReadKey();
        }

        public static void RunRealWorldExample()
        {
            Shop shop = new Shop();

            VehicleBuilder cycleBuilder = new CycleBuilder();
            shop.Construct(cycleBuilder);

            cycleBuilder.Vehicle.ShowVehicle();

            VehicleBuilder truckBuilder = new TruckBuilder();
            shop.Construct(truckBuilder);

            truckBuilder.Vehicle.ShowVehicle();

            Console.ReadKey();
        }
    }
}
