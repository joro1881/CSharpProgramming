//Write a program that extracts from given XML file all the text without the tags. Example:
//<?xml version="1.0"><student><name>Pesho</name>
//<age>21</age><interests count="3"><interest>
//Games</instrest><interest>C#</instrest><interest>
//Java</instrest></interests></student>

using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractXMLallTextNoTags
{
    static void Main()
    {
        string file = @"..\..\XMLfile.txt";
        ExtractionText(file);
    }
    private static void ExtractionText(string inputFile)
    {
        using (StreamReader sourceFile = new StreamReader(inputFile))
        {
            string line = sourceFile.ReadLine();
            while (line != null)
            {
                string brackets = ">[^<]*</";
                string edited;
                int length;
                //we are using foreach because Matches is collections method
                foreach (Match match in Regex.Matches(line, brackets))
                {
                    edited = match.Value.ToString();
                    length = edited.Length;
                    edited = edited.Remove(length - 2, 2); //remove </
                    edited = edited.Remove(0, 1); //remove >
                    if (edited != null)
                    {
                        Console.WriteLine(edited);
                    }
                }
                line = sourceFile.ReadLine();
            }
        }
    }
}

