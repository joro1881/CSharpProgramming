//Write a program that reverses the words in given sentence.
    //Example: INPUT: "C# is not C++, not PHP and not Delphi!" 
             //OUTPUT  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ReversingWordsInSentence
{
    static void Main()
    {
        string text = @"C# is not C++, not PHP and not Delphi!";

        ReversingSentence(text);
    }

    private static void ReversingSentence(string text)
    {
        //setting the separators
        char[] separators = new char[] { ',', ' ', '!', '?', '.' };
        //removing separators, making array of only hole words
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //making string container for later
        StringBuilder reversed = new StringBuilder();
        //making container for separators
        List<string> nonLetters = new List<string>();
        //reversing the order of the words
        Array.Reverse(words);

        //array with separatores
        string[] arr = Regex.Split(text, "[A-Za-z0-9#+]");

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != String.Empty)
            {
                //filling the list container with separators
                nonLetters.Add(arr[i]);
            }
        }

        for (int i = 0; i < nonLetters.Count; i++)
        {
            if (i < words.Length)
            {
                //adding the word to the string container
                reversed.Append(words[i]);
            }

            //adding separator to the string container
            reversed.Append(nonLetters[i]);
        }
        Console.WriteLine(reversed.ToString());
    }
}

