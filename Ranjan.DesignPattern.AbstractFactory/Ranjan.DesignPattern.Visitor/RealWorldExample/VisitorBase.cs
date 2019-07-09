namespace Ranjan.DesignPattern.Visitor.RealWorldExample
{
    public abstract class VisitorBase
    {
        public abstract void Visit(Worker employee);
        public abstract void Visit(Manager employee);
    }
}
