//Write a method that returns the index of the first element
//in array that is bigger than its neighbors, or -1, 
//if there’s no such element.
//Use the method from the previous exercise.

using System;


class ReturnIndex
{
    //choosing array's entity
    public static void SellectArray(int[] arr)
    {
        int max = 20;
        int min = 0;
        Random rand = new Random();
        for (int indexer = 0; indexer < arr.Length; indexer++)
        {
            arr[indexer] = rand.Next(min, max);
        }
    }

    //printing
    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }  

    // method check the element is bigger than neighbors
    static int IndexOfBiggerElement(int[] array)
    {
        int check = -1;
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            if (indexer == array.Length - 1)
            {
                if (array[indexer] > array[array.Length - 2])
                {
                    return indexer;
                }
            }
            else if (indexer == 0)
            {
                if (array[indexer] > array[1])
                {
                    return indexer;
                }
            }
            else if (indexer != 0 && indexer < array.Length && indexer != array.Length - 1)
            {
                if (array[indexer] > array[indexer + 1] && array[indexer] > array[indexer - 1])
                {
                    return indexer;
                }              
            }
        }
        return check;
    }

    static void Main()
    {
        Console.WriteLine("Please choose area size: ");
        string str = Console.ReadLine();
        int size;

        bool parseSuccess = Int32.TryParse(str, out size);
        if (parseSuccess)
        {
            if (size > 1)
            {
                int[] arr = new int[size];
                SellectArray(arr);
                PrintArray(arr);               
                Console.WriteLine(IndexOfBiggerElement(arr));
            }
            else
            {
                Console.WriteLine("Wrong input, please try again: ");
                Main();
            } 
        }
        else
        {
            Console.WriteLine("Wrong input, please try again: ");
            Main();
        }        
    }
}




