//Write a program that reads a text file and inserts line numbers
//in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;

class InsertingLineInFile
{
    static void Main()
    {
        string file = @"..\..\LinedFile.txt";
        string AnotherTextFile = @"..\..\AnotherTextFile.txt";
        StreamReader reader = new StreamReader(file);
        StreamWriter writer = new StreamWriter(AnotherTextFile);
        AddLineCounter(reader, writer);
        PrintingFile(AnotherTextFile);
        
    }

    private static void AddLineCounter(StreamReader reader, StreamWriter writer)
    {
        //open the file for writing in it
        using (writer)
        {
            using (reader)
            {
                //open the first file
                int count = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    //writing the reading from the first file
                    writer.WriteLine("{0}. {1}", count, line);
                    line = reader.ReadLine();
                    count++;
                }
            }
        }
    }
    public static void PrintingFile(string newFile)
    {
        //method for printing
        StreamReader readerBinary = new StreamReader(newFile);
        using (readerBinary)
        {
            string line = readerBinary.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = readerBinary.ReadLine();
            }
        }
    }
}

