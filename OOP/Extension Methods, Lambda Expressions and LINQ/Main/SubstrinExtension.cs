//Implement an extension method Substring
//(int index, int length) for the class StringBuilder 
//that returns new StringBuilder and has the same 
// functionality as Substring in the class String.

using System;
using System.Text;

namespace SubstrinExtension
{
    public static class StringbuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            return new StringBuilder(str.ToString().Substring(index, length));
        }
    }
}
