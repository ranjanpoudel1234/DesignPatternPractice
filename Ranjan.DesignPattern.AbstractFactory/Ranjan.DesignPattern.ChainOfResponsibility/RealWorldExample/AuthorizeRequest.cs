namespace Ranjan.DesignPattern.ChainOfResponsibility.RealWorldExample
{
    public class AuthorizeRequest
    {
        public string OrganizationName { get; set; }
        public AuthorizeTypes AuthorizeType { get; set; }
    }

    public enum AuthorizeTypes
    {
        ReleasedClient = 0,
        ReleasedContractor = 1
    }
}
