using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public class ReleasedContractorAuthorizer : Authorizer
    {
        protected override bool ShouldHandle(AuthorizeRequest request)
        {
            if (request.AuthorizeType == AuthorizeTypes.ReleasedContractor)
            {
                return true;
            }

            return false;
        }

        public override void HandleAuthorization(AuthorizeRequest request)
        {
            Console.WriteLine($"{this.GetType().Name} handled the authorization for organization {request.OrganizationName}");
        }
    }
}
