
using System;
using Figures;

class Program
{
    static void Main()
    {
        Rectangle square = new Rectangle(5, 5);
        double sur = square.CalculateSurface();
        Console.WriteLine("We have square with '5' side,\nthe surface is {0} ", sur);

        Rectangle rec = new Rectangle(6.6, 9.3);
        double surface = rec.CalculateSurface();
        Console.WriteLine("\nWe have rectangle with '6.6' and '9.3' sides, \nthe surface is {0}", surface);

        Triangle trian = new Triangle(5.3,3.5);
        double sur3 = trian.CalculateSurface();
        Console.WriteLine("\nWe have triangle with base '5.3' and 3.5 height, \nthe surface is {0}", sur3);

        Circle cir = new Circle(7.4);
        double rad = cir.CalculateSurface();
        Console.WriteLine("\nWe have Circle with '7.4' raduis,\nthe surface is {0}", rad);
    }
}

