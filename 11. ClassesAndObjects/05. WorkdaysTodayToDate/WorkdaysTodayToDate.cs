//Write a method that calculates the number of workdays between today and given date,
//passed as parameter. Consider that workdays are all days from Monday to Friday 
//except a fixed list of public holidays specified preliminary as array.

using System;

class WorkdaysTodayToDate
{
    private static int day;
    private static int month;
    private static int year;
    private static int workdays;
    private static DateTime[] holidays = {
                                            new DateTime(2013, 01, 1),
                                            new DateTime(2013, 03, 03),
                                            new DateTime(2013, 05, 01),
                                            new DateTime(2013, 05, 24),
                                            new DateTime(2013, 09, 06),
                                            new DateTime(2013, 09, 22),
                                            new DateTime(2013, 11, 01),
                                            new DateTime(2013, 12, 24),
                                            new DateTime(2013, 12, 25),
                                            new DateTime(2013, 12, 26),
                                            new DateTime(2013, 12, 31),
                                         };

    static void Main()
    {
        Console.WriteLine("Set a date for calculating the workdays: ");
        Console.WriteLine();
        SetDate();
        DateTime overDate = new DateTime(year, month, day);
        CalcWorkdays(overDate);

    }

    //logic for calculating the workdays
    public static void CalcWorkdays(DateTime overDate)
    {
        DateTime today = DateTime.Today;
        workdays = (overDate-today).Days;

        while (today <= overDate)
        {
            if (today.DayOfWeek == DayOfWeek.Sunday || today.DayOfWeek == DayOfWeek.Saturday)
            {
                workdays--;
            }
            else
            {
                for (int index = 0; index < holidays.Length; index++)
                {
                    if (today == holidays[index])
                    {
                        workdays--;
                    }
                }
            }
            today = today.AddDays(1);
        }
        Console.WriteLine(workdays);
    }

    //set the over date to which we want calculating
    public static void SetDate()
    {
        DateTime today = DateTime.Today;

        //def the input data
        do
        {
            Console.WriteLine("Give a year, to be in future tense: ");
        } while (!int.TryParse(Console.ReadLine(), out year));
        if (year < today.Year)
        {
            Console.WriteLine("Wrong input, try again");
            SetDate();
        }
        do
        {
            Console.WriteLine("Give a day of the month: ");
        } while (!int.TryParse(Console.ReadLine(), out day));
        if (day > 31 || day <= 0)
        {
            Console.WriteLine("Wrong input, try again");
            SetDate();
        }
        do
        {
            Console.WriteLine("Give a month of the year: ");
        } while (!int.TryParse(Console.ReadLine(), out month));
        if (month > 12 || month <= 0)
        {
            Console.WriteLine("Wrong input, try again");
            SetDate();
        }
    }
}

