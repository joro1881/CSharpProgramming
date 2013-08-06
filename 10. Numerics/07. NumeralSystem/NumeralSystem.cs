//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Collections.Generic;

class NumeralSystem
{
    static int binaryy;
    static int decimaL;
    static string hexadecimal;
    
    // I make program to convert numeral system 2,10,16 to 2,10,16
    // For easier build, i made 3 methods for getting the number (in menu base S)
    // In menu 2 (base D) I make all the calculation with 4 methods ConvertTo...
    // I put some defense for input data, and extract the menuD in method 
    // (we dont need to get back in the begging of the program, like menu 1)

    static void Main()
    {
        byte numeral;
        do
        {
            Console.WriteLine("Set which numeral system will input: (10)decimal! (2)binary! (16)hexadecimal!");
        } while (!byte.TryParse(Console.ReadLine(), out numeral));

        // menu with switch for getting base S
        switch(numeral)
        {
            case 2:
                 binaryy = SetBinaryNumber();
                break;
            case 10:
                decimaL = SetDecimalNumber();
                break;
            case 16:
                hexadecimal = SetHexademicalNumber();
                break;
            default:
                Console.WriteLine("Wrong input, try again: ");
                Main();
                break;
        }

        MenuD(numeral);
    }

    private static void MenuD(byte numeral)
    {
        byte check = numeral;
        byte numeral2;
        do
        {
            Console.WriteLine("Set to which numeral system you want to converting (2)binary! (10)decimal! (16)hexadecimal!");
        } while (!byte.TryParse(Console.ReadLine(), out numeral2));


        // menu with switch for getting base D
        switch (numeral2)
        {
            case 2:
                if (numeral == numeral2)
                {
                    Console.WriteLine("You input same numeral systems");
                    Console.WriteLine(binaryy);
                }
                else if (numeral == 10)
                {
                    Console.WriteLine("Binary presentation: ");
                    ConvertToBinary(decimaL);
                }
                else if (numeral == 16)
                {
                    Console.WriteLine("Binary presentation: ");
                    int DECimal = ConvertToDecimal(hexadecimal);
                    ConvertToBinary(DECimal);
                }
                break;
            case 10:
                if (numeral == numeral2)
                {
                    Console.WriteLine("You input same numeral systems");
                    Console.WriteLine(decimaL);
                }
                else if (numeral == 2)
                {
                    Console.WriteLine("Decimal presentation: ");
                    Console.WriteLine(ConvertToDecimal(binaryy));
                }
                else if (numeral == 16)
                {
                    Console.WriteLine("Decimal presentation: ");
                    Console.WriteLine(ConvertToDecimal(hexadecimal));
                }
                break;
            case 16:
                if (numeral2 == numeral)
                {
                    Console.WriteLine("You input same numeral systems");
                    Console.WriteLine(hexadecimal);
                }
                else if (numeral == 2)
                {
                    Console.WriteLine("Hexadecimal presentation: ");
                    int thirdDecimal = ConvertToDecimal(binaryy);
                    ConvertToHexadecimal(thirdDecimal);
                }
                else if (numeral == 10)
                {
                    Console.WriteLine("Hexadecimal presentation: ");
                    ConvertToHexadecimal(decimaL);
                }
                break;
            default:
                Console.WriteLine("Wrong input, try again: ");
                MenuD(check);
                break;
        }
    }

    private static void ConvertToHexadecimal(int deciNumber)
    {
        List<int> bin = new List<int>();
        int index = 0;
        while (deciNumber > 0)
        {
            bin.Add('0');
            switch (deciNumber % 16)
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
                default: bin[index] = (char)((deciNumber % 16) + 48); break;
            }
            index++;
            deciNumber = deciNumber / 16;
        }
        for (int i = bin.Count - 1; i >= 0; i--)
        {
            Console.Write((char)bin[i]);
        }
        Console.WriteLine();
    }

    private static int ConvertToDecimal(string number)
    {
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
        //logic for converting
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
        return result;
    }

    private static int ConvertToDecimal(int number)
    {
        string str = number.ToString();
        int[] arr = new int[str.Length];

        int j = 0;
        int result = 0;
        int base1 = 1;

        for (int i = str.Length - 1; i >= 0; i--)
        {
            arr[j] = str[i] - '0';
            j++;
        }

        for (int i = 0; i < arr.Length; i++, base1 *= 2)
        {
            result += arr[i] * base1;
        }
        return result;
    }

    private static void ConvertToBinary(int a)
    {
        List<int> bin = new List<int>();
        while (a > 0)
        {
            bin.Add(a % 2);
            a = a / 2;

        }
        Console.WriteLine("The binary number is : ");
        for (int i = bin.Count - 1; i >= 0; i--)
        {
            Console.Write(bin[i]);
        }
        Console.WriteLine();
    }

    private static string SetHexademicalNumber()
    {
        Console.WriteLine("Now set a hexadecimal number for converting");
        string input = Console.ReadLine();
        return input;
    }

    private static int SetDecimalNumber()
    {
        Console.WriteLine("Now set a decimal number for converting");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    private static int SetBinaryNumber()
    {
        Console.WriteLine("Now set a binary number for converting");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
}

