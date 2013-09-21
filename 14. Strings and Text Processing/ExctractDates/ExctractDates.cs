//Write a program that extracts from a given
//text all dates that match the format
//DD.MM.YYYY. Display them in the standard 
//date format for Canada.

using System;
using System.Text.RegularExpressions;
using System.Globalization;

class ExctractDates
{
    static void Main(string[] args)
    {
        string text = "My cousin is born 26.04.1988 she have a mask, my brother is born 14.01.2002";
 
        foreach (var extracted in Regex.Matches(text, @"((((0?[1-9])|[12][0-9]|3[01])\.((0?[13578])|(1[02])))|(((0?[1-9])|[12][0-9]|30)\.((0?[469])|11))|(((0?[1-9])|[12][0-9])\.(0?2)))\.\d{4}"))
        {
            string extractedToString = Convert.ToString(extracted);
            DateTime date = DateTime.ParseExact(extractedToString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA")));
        }
    }
}

