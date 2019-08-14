namespace Ranjan.DesignPattern.Decorator.RealWorldExample
{
    public class Ferrari360 : VehicleBase
    {
        public override string Make
        {
            get { return "Ferrari"; }
        }

        public override string Model
        {
            get { return "360"; }
        }

        public override double HirePrice
        {
            get { return 100; }
        }

        public override int HireLaps
        {
            get { return 10; }
        }
    }
}
