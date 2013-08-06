//Write a program to convert decimal numbers to their binary representation

using System.Collections.Generic;
using System;

class DecimalToBinary
{
    static void Main()
    {
        int decNumber;
        do
        {            
            Console.WriteLine("Set a decimal number for converting: ");

        }while(!int.TryParse( Console.ReadLine(), out decNumber));

        GetBinary(decNumber);
    }

    //method for converting decimal to binary with standard logic
    //we have one List to which we add the digits of the binary number
    private static void GetBinary(int a)
    {
        List<int> bin = new List<int>();
        while (a > 0)
        {            
            bin.Add(a%2);
            a = a / 2;
            
        }
        Console.WriteLine("The binary number is : ");
        for (int i = bin.Count-1; i >=0; i--)
			{
			    Console.Write(bin[i]);
			}
        Console.WriteLine();
    }
}

