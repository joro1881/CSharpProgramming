//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is working correctly.

using System;

public class NumberInArray
{
    static void Main()
    {       
        Console.WriteLine("Please choose area size: ");
        string str = Console.ReadLine();
        int size;

        bool parseSuccess = Int32.TryParse(str, out size);
        if (parseSuccess)
        {
            if (size > 0)
            {
                int[] arr = new int[size];
                SellectArray(arr);
                PrintArray(arr);
                Console.WriteLine();
                NumberAppear(arr, ChooseNumber());
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
        

        //method for testing, if you want to skip it, make it comment
        Console.WriteLine();
        Test();
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

    //choose number for search
    public static int ChooseNumber()
    {
        Console.WriteLine("Please, choose a number for search");
        string str = Console.ReadLine();
        int number;
        bool parseSuccess = Int32.TryParse(str, out number);
        if (parseSuccess)
        {
            return number;
        }
        else
        {
            Console.WriteLine("Wrong input, try again: ");
            ChooseNumber();
            return number;
        }           
    }

    //searching times appearing of number
    public static int NumberAppear(int [] array, int number)
    {        
        int times = 0;
        for (int indexer = 0; indexer < array.Length; indexer++)
        {
            if(array[indexer] == number)
            {
                times++;
            }
        }
        Console.WriteLine("The number we search appears {0,1}", times);
        return times;        
    }

    //test method
    static void Test()
    {
        int[] array = new int[20];
        SellectArray(array);
        PrintArray(array);
        int checkTimes = NumberAppear(array, 5);

        switch (checkTimes)
        {
            case 0:
                if (checkTimes == 0)
                {
                    Console.WriteLine("Passed");
                }
                else Console.Write("Not passed");
                break;
            case 1:
                if (checkTimes == 1)
                {
                    Console.WriteLine("Passed");
                }
                else Console.Write("Not passed");
                break;
            case 2:
                if (checkTimes == 2)
                {
                    Console.WriteLine("Passed");
                }
                else Console.Write("Not passed");
                break;
            default:
                Console.WriteLine("We are not sure of the work of that method, \nWe need to do more tests for validation!");
                break;
        }
    }
}



