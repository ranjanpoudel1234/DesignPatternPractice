namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public interface IAuthorizerChain
    {
        void SetSuccessor(IAuthorizerChain authorizer);

        void ProcessHandler(AuthorizeRequest request);
    }
}
