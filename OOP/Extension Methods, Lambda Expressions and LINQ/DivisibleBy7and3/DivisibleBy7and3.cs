//Write a program that prints from given array 
//of integers all numbers that are divisible 
//by 7 and 3. Use the built-in extension methods 
//and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Linq;

class DivisibleBy7and3
{
    static void Main()
    {
        int[] numbers = new int[100];

        Random rand = new Random();

        for (int i = 0; i < numbers.Length; i++)
			{
			    numbers[i] = rand.Next(0, 500);
                Console.WriteLine(numbers[i]);
			}
        Console.WriteLine();
        //LINQ
        LinqDivisble(numbers);

        //Lambda
        LambdaDivisble(numbers);
    }

    private static void LambdaDivisble(int[] numbers)
    {
        Console.WriteLine("Lambda expression");
        var isDivisble = from num in numbers
                         where num % 7 == 0 && num % 3 == 0
                         select num;

        if (isDivisble.Sum() > 0)
        {
            foreach (int num in isDivisble)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("There is no such numbers");
        }
        Console.WriteLine();
    }

    private static void LinqDivisble(int[] numbers)
    {
        Console.WriteLine("Linq expression");
        var isDivisble = numbers.Where(x => (x % 7 == 0 && x % 3 == 0));

        if (isDivisble.Sum() > 0)
        {
            foreach (int number in isDivisble)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("There is no such numbers");
        }

        Console.WriteLine();
    }
}

