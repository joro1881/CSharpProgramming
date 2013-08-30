//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

class DeletingAllOddLines
{
    private static void CreatingFile(string[] words, string txtFile)
    {
        StreamWriter writer = new StreamWriter(txtFile, false, Encoding.GetEncoding("windows-1251"));

        using (writer)
        {
            for (int index = 1; index < 50; index++)
            {
                if (index % 2 == 1)
                {
                    //setting the word odd
                    writer.WriteLine(words[0]);
                }
                else if (index % 2 == 0)
                {
                    //setting the word even
                    writer.WriteLine(words[1]);
                }
            }
        }
    }

    static void Main()
    {
        try
        {
            string fileName = @"..\..\normalFile.txt";
            string[] words = { "odd", "even" };
            List<string> container = new List<string>();

            CreatingFile(words, fileName);
            Console.WriteLine("The content of the file {0} is: ", fileName);
            PrintingFileContent(fileName);

            DeletingOddLines(fileName, container);
            AddNewData(container, fileName);

            Process openfile = new Process();
            openfile.StartInfo.FileName = fileName;
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

    private static void DeletingOddLines(string fileName,  List<string> content)
    {
        //deleting odd lines
        int lineNumber = 0;
        StreamReader reader = new StreamReader(fileName);

        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                //adding every even line to the list
                lineNumber++;
                if (lineNumber % 2 == 0)
                {
                    content.Add(line);
                    line = reader.ReadLine();
                }
                //i am going to the next line, but i didnt add it to the list
                else
                {
                    line = reader.ReadLine();
                }
            }
        }
    }

    private static void AddNewData(List<string> content, string normalFile)
    {
        //getting the list with all even lines and write it to the file again
        StreamWriter writer = new StreamWriter(normalFile);

        using (writer)
        {
            foreach (string line in content)
            {
                writer.WriteLine(line);
            }
        }
    }

    private static StreamReader PrintingFileContent(string fileName)
    {
        //standard printing of the content
        StreamReader streamReader = new StreamReader(fileName);

        using (streamReader)
        {
            string fileContent = streamReader.ReadToEnd();
            Console.WriteLine(fileContent);
        }
        return streamReader;
    }    
}

