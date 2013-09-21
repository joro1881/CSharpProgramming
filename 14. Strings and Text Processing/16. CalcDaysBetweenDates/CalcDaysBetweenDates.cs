//Write a program that reads two dates in the format:
//day.month.year and calculates the number of days between them. Example:
//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2004
//Distance: 4 days

using System;
using System.Globalization;

class CalcDaysBetweenDates
{
    static void Main()
    {
        string firstDate = "3.03.2004";
        string secondDate = "27.02.2006";

        DateTime first = DateTime.ParseExact(firstDate, "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime second= DateTime.ParseExact(secondDate, "d.MM.yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine("Days between {0} and {1} : ",firstDate, secondDate);
        Console.WriteLine((second - first).TotalDays);
    }
}

