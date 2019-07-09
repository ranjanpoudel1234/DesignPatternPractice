using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Strategy.ConceptExample
{
    class ConceptExample
    {
    }

    /// <summary>

    /// The 'Strategy' abstract class

    /// </summary>

    abstract class Strategy

    {
        public abstract void AlgorithmInterface();
    }

    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>

    class ConcreteStrategyA : Strategy

    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>

    class ConcreteStrategyB : Strategy

    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>

    class ConcreteStrategyC : Strategy

    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    /// <summary>

    /// The 'Context' class

    /// </summary>

    class Context

    {
        private Strategy _strategy;

        // Constructor

        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}
