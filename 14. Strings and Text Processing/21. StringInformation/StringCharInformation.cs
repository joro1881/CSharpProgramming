//Write a program that reads a string 
//from the console and prints all 
//different letters in the string 
//along with information how many
//times each letter is found. 

using System;
using System.Linq;

class StringCharInformation
{
    static void Main()
    {
        string str = Console.ReadLine();

        var chars = str.ToLower().ToCharArray().GroupBy(c => c);
        foreach (var ch in chars) Console.WriteLine("{0}: {1}", ch.Key, ch.Count());
    }
}

