using System; 

namespace GoliathNationalBank
{
    public class Individuals : Customers
    {
        //auto-hide field

        //properties
        private string Name { get; set; }
        private char Sex { get; set; }
        private int Age { get; set; }

        //constructor
        public Individuals(string name, char sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    }
}
