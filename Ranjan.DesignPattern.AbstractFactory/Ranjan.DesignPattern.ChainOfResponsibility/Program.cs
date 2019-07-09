using Ranjan.DesignPattern.ChainOfResponsibility.ConceptExample;
using Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample;
using System;
using System.Collections.Generic;

namespace Ranjan.DesignPattern.ChainOfResponsibility
{
    class Program
    {
        public static void Main()
        {
            // Abstract factory #1
            //RunConceptExample();
            RunRealWorldExample();
            Console.ReadKey();

        }

        public static void RunConceptExample()
        {
            // Setup Chain of Responsibility

            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }

            // Wait for user

            Console.ReadKey();
        }

        //public static void RunRealWorldExample()
        //{
        //    Authorizer releasedClientAuthorizer = new ReleasedClientAuthorizer();
        //    Authorizer releasedContractorAuthorizer = new ReleasedContractorAuthorizer();

        //    //a1.SetSuccessor(a2);
        //    releasedContractorAuthorizer.SetSuccessor(releasedClientAuthorizer);

        //    AuthorizeRequest releaseClientRequest = new AuthorizeRequest
        //    {
        //        AuthorizeType = AuthorizeTypes.ReleasedClient,
        //        OrganizationName = "ReleasedClientOrgName"
        //    };

        //    releasedContractorAuthorizer.HandleAuthorization(releaseClientRequest);


        //    AuthorizeRequest releaseContractorRequest = new AuthorizeRequest
        //    {
        //        AuthorizeType = AuthorizeTypes.ReleasedContractor,
        //        OrganizationName = "ReleasedContractorOrgName"
        //    };

        //    releasedContractorAuthorizer.HandleAuthorization(releaseContractorRequest);
        //}

        public static void RunRealWorldExample()
        {
            var authorizerChain = new IAuthorizerChain []
            {
                new ReleasedClientAuthorizer(),
                new ReleasedContractorAuthorizer()
            };

            for (int i = 0; i < authorizerChain.Length - 1; i++)
            {
                authorizerChain[i].SetSuccessor(authorizerChain[i + 1]);
            }

            AuthorizeRequest releaseClientRequest = new AuthorizeRequest
            {
                AuthorizeType = AuthorizeTypes.ReleasedClient,
                OrganizationName = "ReleasedClientOrgName"
            };

            //Authorizer releasedClientAuthorizer = new ReleasedClientAuthorizer();
            //Authorizer releasedContractorAuthorizer = new ReleasedContractorAuthorizer();

            ////a1.SetSuccessor(a2);
            //releasedContractorAuthorizer.SetSuccessor(releasedClientAuthorizer);

            //releasedContractorAuthorizer.ProcessHandler(releaseClientRequest);

            //AuthorizeRequest releaseContractorRequest = new AuthorizeRequest
            //{
            //    AuthorizeType = AuthorizeTypes.ReleasedContractor,
            //    OrganizationName = "ReleasedContractorOrgName"
            //};

            //releasedContractorAuthorizer.ProcessHandler(releaseContractorRequest);

            authorizerChain[0].ProcessHandler(releaseClientRequest);
       
        }
    }
}
