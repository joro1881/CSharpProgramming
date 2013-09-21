//A dictionary is stored as a sequence of text lines containing words 
//and their explanations. Write a program that enters a word and 
//translates it by using the dictionary. Sample dictionary:

//.NET – platform for applications from Microsoft
//CLR – managed execution environment for .NET
//namespace – hierarchical organization of classes

using System;

class Dictionary
{
    static void Main()
    {
        //Console.WriteLine("Please enter a word for explanation!");
        //string word = Console.ReadLine();
        string word = ".NET";
        TranslatingWord(word);
        Console.WriteLine();
    }

    private static void TranslatingWord(string word)
    {
        string[] dictionary = { ".NET - platform for applications from Microsoft",
                                "CLR - managed execution environment for .NET",
                                "namespace - hierarchical - organization of classes" };

        foreach (string line in dictionary)
        {
            //for each line from dictionary
            //if the index of the given word is 
            //equal to word index[0] in the line
            if (line.IndexOf(word + " - ") == 0)
            {
                //print
                Console.WriteLine(line);
            }
        }
    }
}

