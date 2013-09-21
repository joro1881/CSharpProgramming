//Write a program that converts a string to a 
//sequence of C# Unicode character literals. 
//Use format strings. Sample input:

//Hi!

//Expected output:

//\u0048\u0069\u0021

using System;

class ConvertingStringInUnicode
{
    static void Main()
    {
        //string inputStr = Console.ReadLine();
        string inputStr = "Hi!";
        ConvertingToUnicode(inputStr);
    }

    private static void ConvertingToUnicode(string inputStr)
    {
        //foreach symbol in the string
        foreach (var symbol in inputStr)
        {
            //print the unicode
            Console.Write("\\U{0:X4}", (int)symbol);
        }
        Console.WriteLine();
    }
}

