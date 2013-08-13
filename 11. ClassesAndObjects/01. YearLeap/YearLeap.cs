//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class YearLeap
{
    static void Main()
    {
        //def of the input data
        int year;
        do
        {
            Console.WriteLine("Please enter a year for checking it!");

        } while (!int.TryParse(Console.ReadLine(), out year));

        if (year == 0)
        {
            Console.WriteLine("Zero year, bro, then the Jesus die!");
            Console.WriteLine("Try again: ");
            Main();
        }
        else if (year < 0)
        {
            Console.WriteLine("You can not enter negative year");
            Console.WriteLine("Try again: ");
            Main();
        }
            // the logic
        else
        {
            Console.WriteLine(DateTime.IsLeapYear(year));
        }
    }
}

