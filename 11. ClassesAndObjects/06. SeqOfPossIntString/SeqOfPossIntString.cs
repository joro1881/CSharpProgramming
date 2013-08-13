//You are given a sequence of positive integer values written into a string,
//separated by spaces. Write a function that reads these values from given 
//string and calculates their sum. Example:
        //string = "43 68 9 23 318"  result = 461

using System;

class SeqOfPossIntString
{
    static void Main()
    {
        Console.WriteLine("Set a sequence of positive integers:\n\nNote: seperate the numbers with spaces!");

        string sequence = Console.ReadLine();
        string[] numbers = sequence.Split(' ');
        SumInString(numbers);
    }

    //logic
    private static void SumInString(string []numbers)
    {
        int summary = 0;

        for (int index = 0; index < numbers.Length; index++)
        {
            summary = summary + int.Parse(numbers[index].Trim());
        }
        Console.WriteLine(summary);
    }
}

