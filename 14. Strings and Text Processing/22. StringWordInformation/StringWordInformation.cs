//Write a program that reads a string 
//from the console and lists all 
//different words in the string along
//with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Diagnostics;

class StringWordInformation
{
    static void Main()
    {
        string text = "man i need to stop the time, to have enought time for everything I want! Time is relatively";
        string[] words = text.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> diction = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (diction.ContainsKey(word))
            {
                diction[word] = diction[word] + 1;
            }
            else //(!rechnik.ContainsKey(word))
            {
                diction.Add(word, 1);
            }
        }

        foreach (var word in diction)
        {
            Console.WriteLine("{0,-15} - {1} times", word.Key, word.Value);
        }
    }
}

