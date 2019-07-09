namespace Ranjan.DesignPattern.Visitor.RealWorldExample
{
    public class OrganizationalStructure
    {

        public EmployeeBase Employee { get; set; }

        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
}
