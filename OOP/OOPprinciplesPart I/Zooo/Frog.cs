using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zooo
{
    class Frog : Animal, ISound
    {
        public Frog(string name, char sex, byte age)
            : base(name, sex, age)
        {
        }

        public void AnimalSound()
        {
            Console.WriteLine(this.Name + " -Qwak, qwak-");
        }
    }
}
