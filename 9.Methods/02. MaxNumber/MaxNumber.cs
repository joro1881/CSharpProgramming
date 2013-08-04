//Write a method GetMax() with two parameters that returns the bigger of two integers. 
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class MaxNumber
{
    static int GetMax(int firstNumber, int secondNumber)
    {
        int bigger = firstNumber;
        if (firstNumber < secondNumber)
        {
            bigger = secondNumber;
        }
        return bigger;
    }

    static void Main()
    {
        Console.WriteLine("Please input 3 integer numbers");
        int one = int.Parse(Console.ReadLine());
        int two = int.Parse(Console.ReadLine());
        int three = int.Parse(Console.ReadLine());
        Console.WriteLine(GetMax(GetMax(one, two), three));

    }
}

