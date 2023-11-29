using System;

namespace ToDoApplication
{
    public class Member
    {
        private int id;
        private string firstName;
        private string lastName;

        public Member(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
