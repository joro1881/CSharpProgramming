using System.Text;
using System;
using SubstrinExtension;

class MainTest
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("trala lala");

        Console.WriteLine(sb.Substring(3,6));
    }
}

