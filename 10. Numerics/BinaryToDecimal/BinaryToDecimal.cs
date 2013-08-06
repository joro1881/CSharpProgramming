//Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Set binary number: ");
        string number = Console.ReadLine();
        int[] arr = new int[number.Length];
       
        int j = 0;
        int result = 0;
        int base1 = 1;

        //changing the places of the bits 
        for (int i = number.Length-1; i >= 0; i--)
        {
            arr[j] = number[i]-'0';
            j++;
        }

        //calculating with standard logic
        for (int i = 0; i < arr.Length; i++,base1*=2)
        {
            result += arr[i] * base1;
        }
        Console.WriteLine(result);
    }
}

