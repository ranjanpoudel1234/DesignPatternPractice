using System;
using System.Collections.Generic;
using System.Text;

namespace Ranjan.DesignPattern.Adapter.RealWorldExample
{
    public class PersonnelSystem // Adaptee, this is the class that client(intranet) wants to talk to, but needs an Adapter
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new string[] { "1201", "Jim", "Team Leader" };
            employees[1] = new string[] { "1202", "Bob", "Developer" };
            employees[2] = new string[] { "1203", "Sue", "Developer" };
            employees[3] = new string[] { "1204", "Dan", "Tester" };

            return employees;
        }
    }
}
