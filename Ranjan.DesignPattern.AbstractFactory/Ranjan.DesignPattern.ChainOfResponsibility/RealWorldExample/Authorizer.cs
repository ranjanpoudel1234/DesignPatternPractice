namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public abstract class Authorizer : IAuthorizerChain
    {
        protected IAuthorizerChain successor;

        public void SetSuccessor(IAuthorizerChain authorizer)
        {
            successor = authorizer;
        }

        public void ProcessHandler(AuthorizeRequest request)
        {
            if (ShouldHandle(request))
            {
                HandleAuthorization(request);
            }

            successor?.ProcessHandler(request);
        }

        protected virtual bool ShouldHandle(AuthorizeRequest request) => true;

        public abstract void HandleAuthorization(AuthorizeRequest request);
    }
}
