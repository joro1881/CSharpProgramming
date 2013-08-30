//Write a program that reads a list of words from a file 
//words.txt and finds how many times each of the words is
//contained in another file test.txt. The result should 
//be written in the file result.txt and the words should
//be sorted by the number of their occurrences in 
//descending order. Handle all possible exceptions 
//in your methods.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

class ReadListWordsCountTimes
{
    static void Main()
    {
        try
        {
            //like the previous task
            string[] words = { "testAmigo", "Game", "test", "byyy", "horse" };
            string txtFile = @"..\..\test.txt";
            RandomizationFile(words, txtFile);

            string[] givenwords = File.ReadAllLines(@"..\..\words.txt");
            string[] test = File.ReadAllLines(@"..\..\test.txt");
            string outPut = "";
            string result = @"..\..\result.txt";
            List<int> countedWords = new List<int>();

            outPut = CountWordsWriteResult(givenwords, test, outPut, result, countedWords);

            Process openfile = new Process();
            openfile.StartInfo.FileName = result;
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

    private static string CountWordsWriteResult(string[] givenwords, string[] test, string outPut, string result, List<int> countedWords)
    {
        //checking for each word in the file
        //how many times appears (count)
        //saving the result in list
        //and a string
        foreach (var word in givenwords)
        {
            outPut += "\"" + word + "\" :";
            int count = 0;
            foreach (var item in test)
            {
                if (item == word)
                {
                    count++;
                }
            }
            //in the list is the times of appearence for sort
            countedWords.Add(count);
            //in the string is the word and count
            outPut += count + "\r\n";
        }
        countedWords.Sort();
        //writting the result in the directory file
        StreamWriter writer = new StreamWriter(result);
        using (writer)
        {
            writer.WriteLine(outPut);
            foreach (var item in countedWords)
            {
                writer.WriteLine(item);
            }
        }
        return outPut;
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
}


