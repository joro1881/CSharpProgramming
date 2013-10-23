using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zooo
{
    class Cat : Animal, ISound
    {
        public Cat(string name, char sex, byte age)
            : base(name, sex, age)
        {

        }

        public void AnimalSound()
        {
            Console.WriteLine(this.Name + " -mrrr..mrrrr.zzzz..-");
        }

    }
}
