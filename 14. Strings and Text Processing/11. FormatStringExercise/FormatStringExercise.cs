//Write a program that reads a number and prints it as a 
//decimal number, hexadecimal number, percentage and in 
//scientific notation. Format the output aligned right in 
//15 symbols.

using System;

class FormatStringExercise
{
    static void Main()
    {
        Console.WriteLine("Please input integer number: ");
        int number; 
        string str;
        do
        {
            str = Console.ReadLine();
        }while(!(int.TryParse(str, out number)));

        PrintingNumber(number);
    }

    private static void PrintingNumber(int number)
    {
        Console.WriteLine("Decimal : {0,15:d}", number);
        Console.WriteLine("Hexadecimal : {0,15:X4}", number);
        Console.WriteLine("Percent : {0,15:p}", number);
        Console.WriteLine("Scientific : {0,15:e}", number);
        Console.WriteLine();
    }
}

