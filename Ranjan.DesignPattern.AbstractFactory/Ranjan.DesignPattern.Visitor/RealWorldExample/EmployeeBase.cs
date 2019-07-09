namespace Ranjan.DesignPattern.Visitor.RealWorldExample
{
    public abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public double MonthlySalary { get; set; }
    }
}
