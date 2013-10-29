using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : Shape
    {
        //constructor
        public Triangle(double w, double h)
            : base(w, h)
        {
        }

        //overriden method
        public override double CalculateSurface()
        {
            return (double)(this.Height * this.Width) / 2;
        }
    }
}
