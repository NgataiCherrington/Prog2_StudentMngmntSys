using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Person
    {
        private int id;
        private string lastName;
        private string firstName;

        public Person (int id, string lastName, string firstName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public string DisplayPersonId() => $"ID: {id}";
        public string DisplayPersonName() => $"First name: {firstName}";
        public string DisplayLastName() => $"Surname: {lastName}";
    }
}
