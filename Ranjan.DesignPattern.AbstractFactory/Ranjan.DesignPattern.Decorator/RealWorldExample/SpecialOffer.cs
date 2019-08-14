using System;

namespace Ranjan.DesignPattern.Decorator.RealWorldExample
{
    public class SpecialOffer : VehicleDecoratorBase
    {
        public SpecialOffer(VehicleBase vehicle) : base(vehicle) { }

        public int DiscountPercentage { get; set; }
        public int ExtraLaps { get; set; }

        public override double HirePrice
        {
            get
            {
                double price = base.HirePrice;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price * percentage) / 100, 2);
            }
        }

        public override int HireLaps
        {
            get
            {
                return base.HireLaps + ExtraLaps;
            }
        }
    }
}
