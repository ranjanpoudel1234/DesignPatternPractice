using System;

namespace Ranjan.DesignPattern.Adapter.RealWorldExample
{
    public class Intranet // client looking to talk to get phoneList via the target.
    {
        private readonly IIntranetPhoneList _phoneListSource;

        public Intranet(IIntranetPhoneList phoneListSource)
        {
            _phoneListSource = phoneListSource;
        }

        public void ShowPhoneList()
        {
            string phoneNumbers = _phoneListSource.GetPhoneList();
            Console.WriteLine(phoneNumbers);
        }
    }
}
