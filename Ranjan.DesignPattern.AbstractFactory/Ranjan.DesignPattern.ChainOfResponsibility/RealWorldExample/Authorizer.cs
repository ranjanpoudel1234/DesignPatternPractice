using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public abstract class Authorizer
    {
        protected Authorizer successor;

        public void SetSuccessor(Authorizer authorizer)
        {
            successor = authorizer;
        }

        public abstract void HandleAuthorization(AuthorizeRequest request);
    }
}
