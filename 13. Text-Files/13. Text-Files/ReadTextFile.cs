//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class ReadTextFile
{
    static void Main()
    {
        string fileName = @"..\..\ReadTextFile.cs";
        Console.WriteLine("The content of the file {0} is: ", fileName);

        StreamReader streamReader = new StreamReader(fileName);

        using (streamReader)
        {
            string fileContent = streamReader.ReadToEnd();
            Console.WriteLine(fileContent);
        }

        Console.WriteLine("\n\n Now every odd lines: ");

        //reading the file 
        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            int lineNumber = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber ++;
                // here i enter the odd line 
                if (lineNumber % 2 == 1)
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }
                    //i am going to the next line, but i didnt print it
                else
                {
                    line = reader.ReadLine();
                }
            }
        }
    }
}

