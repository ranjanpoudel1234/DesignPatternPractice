namespace Ranjan.DesignPattern.Decorator.RealWorldExample
{
    public abstract class VehicleBase
    {
        public abstract string Make { get; }
        public abstract string Model { get; }
        public abstract double HirePrice { get; }
        public abstract int HireLaps { get; }
    }
}
