//Write a program that removes from a text file
//all words listed in given another text file.
//Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

class RemovingTextByGivenFile
{
    static void Main()
    {
        try
        {
            //like the previous task
            string[] words = { "testAmigo", "middle - Game", "test" , "byyy", "horse"};
            string txtFile = @"..\..\textFile.txt";
            string givenFile = @"..\..\words.txt";
            RandomizationFile(words, txtFile);
            DeletesText(txtFile, givenFile);

            Process openfile = new Process();
            openfile.StartInfo.FileName = txtFile;
            openfile.Start();
        }
        catch (FileNotFoundException FNFE)
        {
            Console.WriteLine(FNFE.Message);
        }
        catch (NullReferenceException NRE)
        {
            Console.WriteLine(NRE.Message);
        }
        catch (ArgumentNullException ANE)
        {
            Console.WriteLine(ANE.Message);
        }
        catch (IOException IOE)
        {
            Console.WriteLine(IOE.Message);
        }
        finally
        {
            Console.WriteLine("Good Bye");
        }

    }

    private static void RandomizationFile(string[] words, string txtFile)
    {
        //creating a file with 150 words from the array []words
        Random rand = new Random();

        StreamWriter writer = new StreamWriter(txtFile, false, Encoding.GetEncoding("windows-1251"));

        using (writer)
        {
            for (int index = 0; index < 150; index++)
            {
                writer.WriteLine(words[rand.Next(words.Length)]);
            }
        }
    }

    private static void DeletesText(string firstFileName, string word)
    {
        //deleting text using regular expresions
        //first we read and save the word into List
        List<string> nonDeleteText = new List<string>();
        StreamReader reader = new StreamReader(firstFileName);
        using (reader)
        {
            string line = reader.ReadLine();
            //the only diffrence is the regular expresion below
            string pattern = @"\b(" + String.Join("|", File.ReadAllLines("../../words.txt")) + @")\b";
            while (line != null)
            {
                Regex rgx = new Regex(pattern);
                line = rgx.Replace(line, "");
                nonDeleteText.Add(line);
                line = reader.ReadLine();
            }
        }

        //secondly we are writting the saved List back to the file
        StreamWriter writer = new StreamWriter(firstFileName);
        using (writer)
        {
            for (int i = 0; i < nonDeleteText.Count; i++)
            {
                writer.WriteLine(nonDeleteText[i]);
            }
        }
    }
}

