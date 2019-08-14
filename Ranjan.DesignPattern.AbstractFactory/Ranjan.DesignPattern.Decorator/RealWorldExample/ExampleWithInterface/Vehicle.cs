using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Decorator.RealWorldExample.ExampleWithInterface
{
    /// <summary>
    /// The 'Component' interface
    /// </summary>
    public interface IVehicle
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }
}
