//Describe the strings in C#. 
//What is typical for the string data type? 
//Describe the most important methods of the String class.

using System;
using System.Text;

class DescribeStringCsMethods
{
    static void Main()
    {
        string a = "b";
        string b = "a";
        String.Compare(a, b); //compare the two strings and returning integer value (-1, 0, 1)
        String.CompareOrdinal(a, b); //comparing each string evaluating the numberic value, coresponding to System.Char
        String.Concat(a, b); // concatenates two objects
        String.Copy(a); // copy a string
        String.Equals(a, b); //checking is two object are equal, looking also for culture, case and sort rules in the comprasion
        String.IsNullOrEmpty(a); //checking is a string empty or null
        String.Join(a, b); //concat strings with putting separator between them
        String.Format(a, "1"); //Strings can be constructed by using placeholders and formatting strings 
        a.IndexOf('a'); // showing the index of the char symbol from the array
        a.Insert(0, "aa"); //inserting symbols to the string
        a.LastIndexOf('a'); //returning the index of last occurance of the specified char
        a.Contains("a"); //returning integer value for how many times the given symbol or string of symbols occur in the original string  
        a.Remove(0); //deleting all characters from the string, starting of given position, deleting everything to the last position.
        //returning new string as result
        a.Replace("a", "z"); //replacing all "a" char symbols with new one "z"
        a.Split(','); //split the string when find the given char symbol ','
        a.Substring(1); //return new string from given position to the last position of the original string
        a.Trim(); // we are cleaning the white spaces infront and back of the string
        a.ToLower(); // - making all symbols in the string lower// we have few options ToString, , ToCharArray,  ToUpper - making all symbols upper
    }
}

