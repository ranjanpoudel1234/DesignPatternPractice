using System;

namespace Ranjan.DesignPattern.ChainOfResponsibility.ConceptExample
{
    public class ConceptExample
    {
    }

    /// <summary>

    /// The 'Handler' abstract class

    /// </summary>

    abstract class Handler

    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    /// <summary>

    /// The 'ConcreteHandler1' class

    /// </summary>

    class ConcreteHandler1 : Handler

    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    /// <summary>

    /// The 'ConcreteHandler2' class

    /// </summary>

    class ConcreteHandler2 : Handler

    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    /// <summary>

    /// The 'ConcreteHandler3' class

    /// </summary>

    class ConcreteHandler3 : Handler

    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
