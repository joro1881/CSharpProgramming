//Write a program that extracts from a 
//given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;

class ExtractPalindromes
{
    static void Main()
    {
        string text = @"ABBA is not a song. GruopABBA is a team of 2 women and two men. What the f*** is lamal? Is lamal some sort of camellamal? ";
        char[] separators = { ' ', ',', '.', '!', '\n', '\r' };
        string[] splitted = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
  
        foreach (string word in splitted)
        {
            //Console.WriteLine(word);
            bool isPalindrome = true;
            for (int j = 0; j < (word.Length / 2); j++)
            {
                if (word[j] != word[word.Length-1-j])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome&&word.Length>1)
            {
                Console.WriteLine(word);
            }
        }
    }  
}

