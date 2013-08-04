//Write a method that adds two positive integer numbers
//represented as arrays of digits (each array element arr[i] contains a digit; 
//the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

using System;


class AddsTwoPositiveIntegers
{
    static ulong Sum(char[] arrayOne, char[] arrayTwo)
    {
        ulong result = ulong.Parse(String.Join("", arrayOne)) + ulong.Parse(String.Join("", arrayTwo));
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Select two positive integers");
        char[] firstArray = new char[]{};
        char[] secondArray = new char[]{};
        firstArray = Console.ReadLine().ToCharArray();
        secondArray = Console.ReadLine().ToCharArray();        
        Console.WriteLine(Sum(firstArray, secondArray));
    }
}

