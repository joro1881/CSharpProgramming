//Write a program that replaces all occurrences of the substring 
//"start" with the substring "finish" in a text file. Ensure it 
//will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;
using System.Diagnostics;

class ReplacingSubstring
{
    static void Main()
    {
        try
        {
            string[] words = { "start - Game", "middle - Game", "Just Game" };
            string txtFile = @"..\..\textFile.txt";
            string outputFile = @"..\..\finish.txt";

            RandomizationFile(words, txtFile);
            ChangingWordInFile(txtFile, outputFile);

            Process openfile = new Process();
            openfile.StartInfo.FileName = txtFile;
            openfile.Start();

            openfile.StartInfo.FileName = outputFile;
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
        finally
        {
            Console.WriteLine("Good Bye");           
        }
    }

    private static void ChangingWordInFile(string txtFile, string outputFile)
    {
        //taking the data from textFile 
        //and writting it to outputFIle, but with some change:)
        StreamWriter writer = new StreamWriter(outputFile);
        StreamReader reader = new StreamReader(txtFile);
        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(line.Replace("start", "finish"));
                    line = reader.ReadLine();
                }
            }
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
}

