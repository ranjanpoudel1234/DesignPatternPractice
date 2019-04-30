using System;

namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public class ReleasedClientAuthorizer : Authorizer
    {
        public override void HandleAuthorization(AuthorizeRequest request)
        {
            if (request.AuthorizeType == AuthorizeTypes.ReleasedClient)
            {
                Console.WriteLine($"{this.GetType().Name} handled the authorization for organization {request.OrganizationName}");
            }
            else
            {
                successor?.HandleAuthorization(request);
            }
        }
    }
}
