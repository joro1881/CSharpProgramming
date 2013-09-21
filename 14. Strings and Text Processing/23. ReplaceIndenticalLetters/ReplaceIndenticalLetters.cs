//Write a program that reads a string from
//the console and replaces all series of 
//consecutive identical letters with a 
//single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Text;

class ReplaceIndenticalLetters
{
    static void Main()
    {         
        StringBuilder str = new StringBuilder("aaaaabbbbbcdddeeeedssaa");
        for (int i = 0,index=0; i < str.Length-1; i++,index++)
        {
            char currentLetter = str[i];
            //we check the letter taken of first cycle [i] with the 
            //next one, taken by second cycle [index+1]
            //if we have a match - remove the second letter
            //break the second cycle, take the [i] first cycle
            while (index<str.Length-1 &&currentLetter == str[index+1])
            {
                str.Remove(index+1, 1);
                Console.WriteLine(str);
            }
        }
        Console.WriteLine(str);
    }
}

