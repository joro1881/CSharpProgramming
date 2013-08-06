//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Text;

class BinaryToHexadecimal
{    
    static void Main()
    {
        Console.WriteLine("Set binary number for converting:");
        string input = Console.ReadLine();
        BinaryToX(input);
    }

    //method for directly converting binary to hexadecimal
    // I add zeros to make the input even, then we use switch and make the calcs :) 

    private static void BinaryToX(string number)
    {
        int lenght = number.Length;
        StringBuilder str = new StringBuilder();

        for (int i = 4; i < 32; i*=2)
        {
            if (lenght < i)
            {
                string addZeros = new string('0', i - number.Length);
                number = addZeros + number;
                break;
            }
        }

        for (int index = 0; index < lenght; index = index+4)
        {
            switch (number.Substring(index, 4))
            {
                case "0000":
                    str.Append("0");
                    break;
                case "0001":
                    str.Append("1");
                    break;
                case "0010":
                    str.Append("2");
                    break;
                case "0011":
                    str.Append("3");
                    break;
                case "0100":
                    str.Append("4");
                    break;
                case "0101":
                    str.Append("5");
                    break;
                case "0110":
                    str.Append("6");
                    break;
                case "0111":
                    str.Append("7");
                    break;
                case "1000":
                    str.Append("8");
                    break;
                case "1001":
                    str.Append("9");
                    break;
                case "1010":
                    str.Append("A");
                    break;
                case"1011":
                    str.Append("B");
                    break;
                case "1100":
                    str.Append("C");
                    break;
                case "1101":
                    str.Append("D");
                    break;
                case"1110":
                    str.Append("E");
                    break;
                case "1111":
                    str.Append("F");
                    break;
            }
        }
        Console.WriteLine(str);
    }
}

