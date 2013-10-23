using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zooo
{
    class Tomcat : Cat
    {
        public Tomcat(string name, byte age)
            : base(name, 'm', age)
        {
        }
    }
}
