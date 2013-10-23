using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class SchoolSecondary
    {
        //classes of students
        public string Name { get; set; }
        List<SetOfClasses> classes;

        public SchoolSecondary(string school)
        {
            this.classes = new List<SetOfClasses>();
            this.Name = school;
        }
    }
}
