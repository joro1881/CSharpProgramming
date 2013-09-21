//We are given a string containing a list of forbidden words 
//and a text containing some of these words. Write a program 
//that replaces the forbidden words with asterisks. Example:

//Microsoft announced its next generation PHP compiler today. 
//It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
//Words: "PHP, CLR, Microsoft
//The expected result:

//********* announced its next generation *** compiler today. 
//It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Text.RegularExpressions;

class ReplacingForbiddenWords
{
    static void Main()
    {
        string text = 
        @"Microsoft announced its next generation PHP compiler today.
        It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string []words = {"PHP", "CLR", "Microsoft"};

        Console.WriteLine(text = ReplacingWords(text, words));
        
    }

    private static string ReplacingWords(string text, string[] words)
    {
        //for each word in [] we replacing with * 
        for (int i = 0; i < words.Length; i++)
        {
            //the logic
            text = text.Replace(words[i], new string('*', words.Length));
        }
        return text;
    }
}

