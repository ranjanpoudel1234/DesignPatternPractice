using System;
using Ranjan.DesignPattern.Decorator.RealWorldExample;

namespace Ranjan.DesignPattern.Decorator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DemonstrateDecorator();
            Console.ReadKey();
        }

        public static void DemonstrateDecorator()
        {
            var ferrariCar = new Ferrari360();
            Console.WriteLine("Base price is {0:c} for {1} laps.", ferrariCar.HirePrice, ferrariCar.HireLaps);

            var offer = new SpecialOffer(ferrariCar)
            {
                DiscountPercentage = 25,
                ExtraLaps = 2
            };
            Console.WriteLine("Offer price is {0:c} for {1} laps.", offer.HirePrice, offer.HireLaps);
            Console.WriteLine("Base price STILL REMAINS AT {0:c} for {1} laps.", ferrariCar.HirePrice, ferrariCar.HireLaps);

            var firstHire = new Hireable(ferrariCar);
            firstHire.Hire("Bob");

            var secondHireWithOffer = new Hireable(offer);
            secondHireWithOffer.Hire("Bill");

            Console.WriteLine("Base price STILL REMAINS AT {0:c} for {1} laps.", ferrariCar.HirePrice, ferrariCar.HireLaps);

        }
    }
}
