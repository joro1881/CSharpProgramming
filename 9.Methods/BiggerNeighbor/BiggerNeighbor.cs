//Write a method that checks if the element at given position
//in given array of integers is bigger than its two neighbors (when such exist).

using System;

class BiggerNeighbor
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

    //choose element for check
    public static int ChooseElement()
    {
        Console.WriteLine("Please, choose a number for search");
        string str = Console.ReadLine();
        int number;
        bool parseSuccess = Int32.TryParse(str, out number);
        if (parseSuccess)
        {
            if (number >= 0)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Wrong input, try again: ");
                ChooseElement();
                return number;
            }
        }
        else
        {
            Console.WriteLine("Wrong input, try again: ");
            ChooseElement();
            return number;
        }
    }

    // method check the element is bigger than neighbors
    static void BiggerCheck(int[] array, int number)
    {
        if (number > array.Length)
        {
            Console.WriteLine("The position you choosed is not in the array,\ntry again: ");
            Main();           
        }
        if (number == array.Length-1)
        {
            if (array[number] > array[array.Length - 2])
            {
                Console.WriteLine("The element of position {0} is bigger than {1}!", number, array[array.Length - 2]);
            }
            else Console.WriteLine("The element is not bigger than his neighbors");
        }
        if (number == 0)
        {
            if (array[number] > array[1])
            {
                Console.WriteLine("The element of position {0} is bigger than {1}!", number, array[1]);
            }
            else Console.WriteLine("The element is not bigger than his neighbors");

        }
        if(number !=0 && number< array.Length && number != array.Length-1)
        {
            if(array[number]>array[number+1] && array[number]>array[number-1])
            {
                Console.WriteLine("The element of position {0} is bigger than {1} , {2}", number, array[number + 1], array[number - 1]);
            }
            else Console.WriteLine("The element of position {0} is not bigger than {1} and {2}", number, array[number-1],array[number+1]);
        }      
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
                BiggerCheck(arr, ChooseElement());
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

