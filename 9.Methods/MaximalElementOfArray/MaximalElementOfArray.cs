//Write a method that return the maximal element
//in a portion of array of integers starting at 
//given index. Using it write another method that
//sorts an array in ascending / descending order.

using System;
using System.Linq;

class MaximalElementOfArray
{
    //sorting the array
    static int[] SortArrayDescending(int [] array)
    {
        int maxElementIndex = 0;
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            maxElementIndex = FindMaximalElement(array, indexer);
            int contain = array[maxElementIndex];
            array[maxElementIndex] = array[indexer];
            array[indexer] = contain;
        }
        return array;
    }

    static int[] SortAscending(int[] array)
    {
        int[] sorted = SortArrayDescending(array);
        sorted = sorted.Reverse().ToArray();
        return sorted;
    }

    //finding maximal element
    static int FindMaximalElement(int[] array, int startIndex)
    {
        int maxElement = startIndex;
        for (int indexer = startIndex + 1; indexer < array.Length; indexer++)
        {
            if (array[maxElement] < array[indexer])
            {
                maxElement = indexer;
            }
        }
        return maxElement;
    }

    //printing
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Choose length for the array: ");
        string str = Console.ReadLine();
        int size;
        bool parseSuccess = int.TryParse(str, out size);
        if (parseSuccess)
        {
            if (size > 0)
            {
                int[] array = new int[size];
                Random rand = new Random();
                int min = 0;
                int max = 15;
                for (int indexer = 0; indexer < array.Length; indexer++)
                {
                    array[indexer] = rand.Next(min, max);
                }
                PrintArray(array);
                //index = 3;
                Console.WriteLine("Maximal element: ");
                Console.WriteLine(FindMaximalElement(array, 3));
                int[] sortedArr = SortAscending(array);
                Console.WriteLine("The array in ascending order: ");
                PrintArray(sortedArr);
                Console.WriteLine("The array in descending order: ");
                sortedArr = SortArrayDescending(array);
                PrintArray(sortedArr);                
            }
            else
            {
                Console.WriteLine("Wrong input, try again: ");
                Main();
            }
        }
        else
        {
            Console.WriteLine("Wrong input, try again: ");
            Main();
        }
    }
}

