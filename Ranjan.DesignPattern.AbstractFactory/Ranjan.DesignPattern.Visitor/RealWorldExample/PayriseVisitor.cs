using System;

namespace Ranjan.DesignPattern.Visitor.RealWorldExample
{
    public class PayriseVisitor : VisitorBase
    {
        double _multiplier;

        public double TotalIncrease { get; private set; }

        public PayriseVisitor(double multiplier)
        {
            _multiplier = multiplier;
            TotalIncrease = 0;
        }

        public override void Visit(Worker employee)
        {
            double increase = employee.MonthlySalary * _multiplier;
            employee.MonthlySalary += increase;
            TotalIncrease += increase;
            Console.WriteLine("{0} salary increased by {1}.", employee.Name, increase);
        }

        public override void Visit(Manager employee)
        {
            double increase = employee.MonthlySalary * _multiplier;
            employee.MonthlySalary += increase;
            TotalIncrease += increase;
            Console.WriteLine("{0} salary increased by {1}.", employee.Name, increase);
        }
    }
}
