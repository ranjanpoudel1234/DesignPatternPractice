using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Visitor.ConceptExample
{
    public class ObjectStructure
    {
        public List<ElementBase> Elements { get; private set; }

        public ObjectStructure()
        {
            Elements = new List<ElementBase>();
        }

        public void Accept(VisitorBase visitor)
        {
            foreach (ElementBase element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }


    public abstract class ElementBase
    {
        public abstract void Accept(VisitorBase visitor);
    }


    public class ConcreteElementA : ElementBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }

        public string Name { get; set; }
    }


    public class ConcreteElementB : ElementBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }

        public string Title { get; set; }
    }


    public abstract class VisitorBase
    {
        public abstract void Visit(ConcreteElementA element);

        public abstract void Visit(ConcreteElementB element);
    }


    public class ConcreteVisitorA : VisitorBase
    {
        public override void Visit(ConcreteElementA element)
        {
            Console.WriteLine("VisitorA visited ElementA : {0}", element.Name);
        }

        public override void Visit(ConcreteElementB element)
        {
            Console.WriteLine("VisitorA visited ElementB : {0}", element.Title);
        }
    }


    public class ConcreteVisitorB : VisitorBase
    {
        public override void Visit(ConcreteElementA element)
        {
            Console.WriteLine("VisitorB visited ElementA : {0}", element.Name);
        }

        public override void Visit(ConcreteElementB element)
        {
            Console.WriteLine("VisitorB visited ElementB : {0}", element.Title);
        }
    }
}
