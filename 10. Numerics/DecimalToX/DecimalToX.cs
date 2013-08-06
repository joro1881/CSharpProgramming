//Write a program to convert decimal numbers to their hexadecimal representation.


using System;
using System.Collections.Generic;

class DecimalToX
{
    static void Main()
    {
        int decNumber;
        do
        {
            Console.WriteLine("Set a decimal number for converting: ");

        } while (!int.TryParse(Console.ReadLine(), out decNumber));

        GetX(decNumber);

    }

    //method for converting decimal to hexadecimal
    // I am using switch to turn some numbers to hexadecimal values
    private static void GetX(int a)
    {
        List<int> bin = new List<int>();
        int index = 0;
        while (a > 0)
        {
            bin.Add('0');
            switch (a % 16)
            {
                case 10:
                    bin[index] = 'A'; break;
                case 11: 
                    bin[index] = 'B'; break;
                case 12:
                    bin[index] = 'C'; break;
                case 13:
                    bin[index] = 'D'; break;
                case 14: 
                    bin[index] = 'E'; break;
                case 15:
                    bin[index] = 'F'; break;
                default: bin[index] = (char)((a % 16) + 48); break;
            }
            index++;
            a = a / 16;
        }
        for (int i = bin.Count - 1; i >= 0; i--)
        {
            Console.Write((char)bin[i]);
        }
    }
}

