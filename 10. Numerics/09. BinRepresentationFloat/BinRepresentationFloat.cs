//* Write a program that shows the internal binary 
//representation of given 32-bit signed floating-point
//number in IEEE 754 format (the C# type float). 
//Example: -27,25  sign = 1, exponent = 10000011,
//mantissa = 10110100000000000000000.

using System;

class BinRepresentationFloat
{
    static void Main()
    {
        float number;
        do{
            Console.WriteLine("Set float number: ");

        }while(!float.TryParse(Console.ReadLine(), out number));

        int sign = 0;

        //define sign of the number
        if (number < 0)
        { 
            sign = 1; number = -1 * number; 
        }

        Console.WriteLine("Sign = {0}", sign);

        //define exponent of the number
        Console.Write("Exponent = ");

        int exponent = 0;
        int indexer;
        //setting the exponent
        for (indexer = 0; indexer <= number; indexer++)  
        {
            exponent = (int)Math.Pow(2, indexer);
            if (exponent >= number) 
            { 
                break;
            }
        }

        //count the exponent
        exponent = (indexer - 1) + 127;   

        //printing
        for (int jugger = 7; jugger >= 0; jugger--)   
        {
            int multiple = (int)Math.Pow(2, jugger);
            int digit = (int)(exponent / multiple);
            exponent = exponent % multiple;

            Console.Write(digit);
        }
        Console.WriteLine();

        //define the mantissa of the number
        Console.Write("Mantissa = ");

        double mantissa = (double)number / Math.Pow(2, indexer - 1);
        mantissa = mantissa - 1;

        for (indexer = 1; indexer < 24; indexer++)
        {
            double multiple = Math.Pow(2, -indexer);
            if (mantissa - multiple >= 0)
            {
                Console.Write(1);
                mantissa = mantissa - multiple;
            }
            else
            {
                Console.Write(0);
            }
        }
        Console.WriteLine();        
    }
}

