using DefiningExceptionClass;
using System;

class Program
{
    static void Main()
    {
        //[1-100]
        //dates [1.1.1980....31.12.2013]
        InvalidRangeException<int> except = new InvalidRangeException<int>("The number is out of the necessary range!", 1, 100);
        Console.WriteLine("Set numbers from 0 - 100:");

        for (int i = 0; i < 3; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < except.Start || number > except.End)
            {
                throw except;
            }
            else Console.WriteLine("Valid number!");
        }

        string startDate = "1/1/1980";
        string endDate = "31/12/2013";

        InvalidRangeException<DateTime> exceptTime =
            new InvalidRangeException<DateTime>("The date don't apply for the search", DateTime.Parse(startDate), DateTime.Parse(endDate));
        Console.WriteLine("Insert date for searching in dates [1.1.1980....31.12.2013]");

        for (int i = 0; i < 3; i++)
        {
            DateTime date = DateTime.Parse(Console.ReadLine()); 
            if (date.Year < exceptTime.Start.Year || date.Year > exceptTime.End.Year)
            {
                throw exceptTime;
            }
            else Console.WriteLine("The date exist");

        }

    }
}

