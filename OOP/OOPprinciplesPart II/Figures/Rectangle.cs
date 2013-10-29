using System; 

namespace Figures
{
    public class Rectangle : Shape
    {
        //constructor
        public Rectangle(double w, double h)
            : base(w, h)
        {

        }

        //overriden method
        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
