using System;

namespace Ranjan.DesignPattern.Decorator.ConceptExample
{
    public class ConceptExample
    {
    }

    public abstract class ComponentBase
    {
        public abstract void Operation();
    }


    public class ConcreteComponent : ComponentBase
    {
        public override void Operation()
        {
            Console.WriteLine("Component Operation");
        }
    }


    public abstract class DecoratorBase : ComponentBase
    {
        private ComponentBase _component;

        public DecoratorBase(ComponentBase component)
        {
            _component = component;
        }

        public override void Operation()
        {
            _component.Operation();
        }
    }


    public class ConcreteDecorator : DecoratorBase
    {
        public ConcreteDecorator(ComponentBase component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("(modified)");
        }
    }
}
