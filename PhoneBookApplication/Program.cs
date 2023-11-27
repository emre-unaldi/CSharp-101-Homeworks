using PhoneBookApplication;
using System;

namespace PhoneBookApplicaton
{
    class Program
    {
        public static void Main(string[] args)
        {
            TelephoneDirectory directory = new TelephoneDirectory(new DirectoryOperationsManager());
            directory.Start();
        }
    }
}