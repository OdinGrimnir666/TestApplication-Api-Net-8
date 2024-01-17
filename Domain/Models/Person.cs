using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Person
    {
        public Guid Id { get; set; } =  Guid.NewGuid();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public void UpdateFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
        }
    }
}
