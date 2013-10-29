using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Shape
    {
        //constructor
        public Circle(double raduis)
            : base(raduis)
        {

        }

        //overriden method
        public override double CalculateSurface()
        {
            return Math.PI * this.Width * 2;
        }
    }
}
