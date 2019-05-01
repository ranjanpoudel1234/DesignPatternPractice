using System;

namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public class ReleasedClientAuthorizer : Authorizer
    {
        protected override bool ShouldHandle(AuthorizeRequest request)
        {
            if (request.AuthorizeType == AuthorizeTypes.ReleasedClient)
            {
                return true;
            }

            return false;
        }

        public override void HandleAuthorization(AuthorizeRequest request)
        {

            Console.WriteLine(
                $"{this.GetType().Name} handled the authorization for organization {request.OrganizationName}");
        }
    }
}
