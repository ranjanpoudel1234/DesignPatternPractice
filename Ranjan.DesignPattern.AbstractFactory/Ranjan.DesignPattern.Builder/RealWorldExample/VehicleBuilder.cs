namespace Ranjan.DesignPattern.Builder.RealWorldExample
{
    public abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }

        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
        public abstract void BuildTires();
    }
}
