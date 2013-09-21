//Write a program that reads a list of words,
//separated by spaces and prints the list 
//in an alphabetical order.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "sign", "abbba", "like", "young", "wahen", "did", "was"};

        //var sortedWords = inWords.OrderBy(x => x); //.ThenBy(x => x.Length);
        Array.Sort(words);
        foreach (var item in words)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }    
}
