namespace Ranjan.DesignPattern.Builder.RealWorldExample
{
    public class CycleBuilder : VehicleBuilder
    {
        public CycleBuilder()
        {
            vehicle = new Vehicle("Cycle");
         // vehicle["test"] = "te"; TIHS IS SO COOL, THIS ALLOWS YOU TO USE STRING LITERALS ALMOST LIKE JAVASCRIPT!!
            Vehicle.Name = "Cycle";
        }

        public override void BuildEngine()
        {
            Vehicle.EngineType = EngineType.SmallEngine;
        }

        public override void BuildFrame()
        {
            Vehicle.Frame = "Cycle long Frame";
        }

        public override void BuildTires()
        {
            Vehicle.NumberOfTires = "2";
        }
    }
}
