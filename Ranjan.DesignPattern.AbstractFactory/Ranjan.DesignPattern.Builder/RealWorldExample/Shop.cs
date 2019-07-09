using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Builder.RealWorldExample
{
    public class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildTires();
        }
    }
}
