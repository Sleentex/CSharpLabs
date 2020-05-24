using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSharp
{
    class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public int Year { get => BirthDate.Year; set => BirthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); }

        public Person()
        {
            _firstName = "Misha";
            _lastName = "Morarash";
            _birthDate = new DateTime(1999, 10, 23);
        }

        public Person(string f_name, string l_name, DateTime birthday)
        {
            _firstName = f_name;
            _lastName = l_name;
            _birthDate = birthday;
        }

        public override string ToString()
        {
            return _lastName + " " + _firstName + " " + _birthDate.ToLongDateString();
        }

        public virtual string ToShortString()
        {
            return _lastName + " " + _firstName;
        }
    }
}
