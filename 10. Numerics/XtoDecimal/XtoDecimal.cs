//Write a program to convert hexadecimal numbers to their decimal representation.

using System;
using System.Collections.Generic;

class XtoDecimal
{
    static void Main()
    {
        Console.WriteLine("Set hexadecimal number: ");
        string number = Console.ReadLine();
        char[] arr = new char[number.Length];
       
        int j = 0;
        int result = 0;
        int base1 = 1;
        int numIndex = 0;

        // making the indexes in order for converting
        for (int i = number.Length - 1; i >= 0; i--)
        {
            arr[j] = number[i];
            j++;
        }
        //logic for converting, using switch 
        for (int indexer = 0; indexer < arr.Length; indexer++, base1 *= 16)
        {
            switch (arr[indexer])
            {
                case 'A':
                case 'a':
                    numIndex = 10; break;
                case 'B':
                case 'b':
                    numIndex = 11; break;
                case 'C':
                case 'c':
                   numIndex = 12; break;
                case 'D':
                case 'd':
                    numIndex = 13; break;
                case 'E':
                case 'e':
                    numIndex = 14; break;
                case 'F':
                case 'f':
                    numIndex = 15; break;
                default:
                    numIndex = int.Parse(Convert.ToString(arr[indexer])); break;
            }
            result += numIndex * base1;
        }
        Console.WriteLine(result);
    }
}

