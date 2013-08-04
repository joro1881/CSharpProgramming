//Write methods to calculate minimum, maximum, 
//average, sum and product of given set of 
//integer numbers. Use variable number of arguments.
 
//* Modify your last program and try to make 
//it work for any number type, not just integer 
//(e.g. decimal, float, byte, etc.). 
//Use generic method 
//(read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;

class MinMaxAveSumPro
{
    //Minimum of set
    static T Minimum<T>(params T[] array)
    {
        dynamic min = array[0];
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            if (array[indexer] < min)
            {
                min = array[indexer];
            }
        }
        return min;
    }

    //Maximum of set
    static T Maximum<T>(params T[] array)
    {
        dynamic max = array[0];
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            if (array[indexer] > max)
            {
                max = array[indexer];
            }
        }
        return max;
    }

    //Average of set
    static T Average<T>(params T[] array)
    {
        dynamic sum = 0;
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            sum += array[indexer];
        }
        return (sum / array.Length);
    }

    //Sum of set
    static T Summary<T>(params T[] array)
    {
        dynamic sum = 0;
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            sum += array[indexer];
        }
        return sum;
    }

    //Product of set
    static T Product<T>(params T[] array)
    {
        dynamic pro = 1;
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            pro *= array[indexer];
        }
        return pro;
    }

    static void Main()
    {
        decimal min = Minimum(2.1m, 3.111m, 3.4453m);
        decimal max = Maximum(2.1m, 3.111m, 3.4453m);
        decimal sum = Summary(2.1m, 3.111m, 3.4453m);
        decimal aver = Average(2.1m, 3.111m, 3.4453m);
        decimal prod = Product(2.1m, 3.111m, 3.4453m);

        int checkmin = Minimum(2, 3, 4);
        int checkmax = Maximum(2, 3, 4);
        int checksum = Summary(2, 3, 4);
        int checkaver = Average(2, 3, 4);
        int checkprod = Product(2, 3, 4);

        Console.WriteLine("Decimal numbers: ");
        Console.WriteLine("Min: {0}\nMax: {1}\nSum: {2}\nAverage: {3}\nProduct: {4}", min, max, sum, aver, prod);
        Console.WriteLine();
        Console.WriteLine("Integers: ");
        Console.WriteLine("Min: {0}\nMax: {1}\nSum: {2}\nAverage: {3}\nProduct: {4}", checkmin, checkmax, checksum, checkaver, checkprod);
    }
}

