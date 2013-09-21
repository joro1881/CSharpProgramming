//Write a program that reads a string, reverses it and
//prints the result at the console.
//Example: "sample"  "elpmas".

using System;

class ReverseStringOnConsole
{
    static void Main()
    {
        //every string is array of char symbols, so we can easly 
        //print it with cycle, in case reverse cycle 
        string example = "sample";
        for (int i = example.Length - 1; i >= 0; i--)
        {
            Console.Write(example[i]);
        }
        Console.WriteLine();
    }
}

