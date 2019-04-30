using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public class ReleasedContractorAuthorizer : Authorizer
    {
        public override void HandleAuthorization(AuthorizeRequest request)
        {
            if (request.AuthorizeType == AuthorizeTypes.ReleasedContractor)
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
