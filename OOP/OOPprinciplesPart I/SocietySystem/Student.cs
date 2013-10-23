using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySystem
{
    public class Student : Human
    {
        public byte Grade { get; set; }

        public Student(string firstName, string lastName, byte grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
}
