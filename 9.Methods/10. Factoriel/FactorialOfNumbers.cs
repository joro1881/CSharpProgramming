//Write a program to calculate n! for each n in 
//the range [1..100]. Hint: Implement first a
//method that multiplies a number represented 
//as array of digits by given integer number. 

using System;
using System.Numerics;

class FactorialOfNumbers
{
    //factorial
    static BigInteger Factorial(int indexer)
    {
        BigInteger numberFac = 1;
        for (; indexer > 0; indexer--)
        {
            numberFac *= indexer;
        }     
        return numberFac;
    }

    //calculating factorial of N
    static void CalculatingFactorialN(int []array)
    {
        for (int jugger = 0; jugger < array.Length; jugger++)
        {
            BigInteger N = Factorial(array[jugger]);
            Console.WriteLine(N);
        }
    }

    static void Main()
    {
        int[] array = new int[100];
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            array[indexer] = indexer + 1;
        }
        CalculatingFactorialN(array);
    }
}

