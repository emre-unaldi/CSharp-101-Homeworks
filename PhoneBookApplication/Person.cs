using System;

namespace PhoneBookApplication
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;

        public Person(string firstName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        public Person() { }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
