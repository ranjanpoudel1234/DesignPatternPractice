using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Builder.RealWorldExample
{
    public class TruckBuilder : VehicleBuilder
    {
        public TruckBuilder()
        {
            vehicle = new Vehicle("Truck");
        }
        public override void BuildEngine()
        {
            vehicle.EngineType = EngineType.BigEngine;
        }

        public override void BuildFrame()
        {
            vehicle.Frame = "Truck Large Frame";
        }

        public override void BuildTires()
        {
            vehicle.NumberOfTires = "18 Wheels";
        }
    }
}
