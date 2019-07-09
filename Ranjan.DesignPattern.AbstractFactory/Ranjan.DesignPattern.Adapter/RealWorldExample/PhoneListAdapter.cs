using System;
using System.Text;

namespace Ranjan.DesignPattern.Adapter.RealWorldExample
{
    public class PhoneListAdapter : IIntranetPhoneList
    {
        private PersonnelSystem _personnelSystem;

        public PhoneListAdapter(PersonnelSystem personnelSystem)
        {
            _personnelSystem = personnelSystem;
        }

        public string GetPhoneList()
        {
            string[][] employees = _personnelSystem.GetEmployees();
            StringBuilder phoneList = new StringBuilder();

            foreach (string[] employee in employees)
            {
                phoneList.Append(employee[1]);
                phoneList.Append(',');
                phoneList.Append(employee[2]);
                phoneList.Append(',');
                phoneList.Append(employee[0]);
                phoneList.Append('\n');
            }

            return phoneList.ToString();
        }
    }
}
