using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zooo
{
    class Kitten : Cat
    {
        public Kitten(string name, byte age)
            : base(name, 'f', age)
        {
        }
        
    }
}
