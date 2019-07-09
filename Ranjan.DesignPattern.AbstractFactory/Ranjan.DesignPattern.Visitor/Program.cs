using System;
using Ranjan.DesignPattern.Visitor.RealWorldExample;

namespace Ranjan.DesignPattern.Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager bob = new Manager();
            bob.Name = "Bob";
            bob.MonthlySalary = 5000;

            Manager sue = new Manager();
            sue.Name = "Sue";
            sue.MonthlySalary = 4000;

            Worker jim = new Worker();
            jim.Name = "Jim";
            jim.MonthlySalary = 2000;

            Worker tom = new Worker();
            tom.Name = "Tom";
            tom.MonthlySalary = 1800;

            Worker mel = new Worker();
            mel.Name = "Mel";
            mel.MonthlySalary = 1900;

            bob.Subordinates.Add(sue);
            bob.Subordinates.Add(jim);
            sue.Subordinates.Add(tom);
            sue.Subordinates.Add(mel);

            OrganizationalStructure org = new OrganizationalStructure(bob);

            PayrollVisitor payroll = new PayrollVisitor();
            PayriseVisitor payrise = new PayriseVisitor(0.05);

            org.Accept(payroll);
            org.Accept(payrise);
            org.Accept(payroll);

            Console.WriteLine("Total pay increase = {0}.", payrise.TotalIncrease);
            Console.ReadKey();
        }
    }
}
