//Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class ReversingDecimal
{
    //method for Reversing digits
    static void DigitsReversed(decimal number)
    {
        string reversed = number.ToString();
        char[] array = reversed.ToCharArray();
        Array.Reverse(array);
        new string(array);
        Console.WriteLine(array);
    }
    static void Main()
    {
        Console.WriteLine("Please, choose decimal number for reversing:");
        string str = Console.ReadLine();
        decimal deco;
        bool parseSuccess = decimal.TryParse(str, out deco);
        if (parseSuccess)
        {
            DigitsReversed(deco);
        }
        else
        {
            Console.WriteLine("Wrong input, try again: ");
            Main();
        }

    }
}

