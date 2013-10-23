using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zooo
{
    public abstract class Animal
    {
        public byte Age { get; set; }
        public char Sex { get; set; }
        public string Name { get; set; }

        public Animal(string name, char sex, byte age)
        {
            this.Age = age;
            this.Sex = sex;
            this.Name = name;
        }

        public void TypeAnimal()
        {
            Console.WriteLine("This animal is " + GetType().Name);
        }

        public static double Average(Animal[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i].Age;
            }

            return sum / arr.Length;
        }
    }
}
