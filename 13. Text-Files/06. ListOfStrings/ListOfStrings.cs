//Write a program that reads a text file containing a list of strings, 
//sorts them and saves them to another text file. Example:
//    Ivan			    George
//    Peter		--->    Ivan
//    Maria		        Maria
//    George			Peter

using System;
using System.IO;
using System.Collections.Generic;

class ListOfStrings
{
    static void Main()
    {
        try
        {
            string inputFile = @"..\..\names.txt";
            string outputFile = @"..\..\orderedNames.txt";
            List<string> namesListOfFile = new List<string>();

            Console.WriteLine("Source of the input file:\n");
            StreamReader reader = new StreamReader(inputFile);
            ReadingFile(namesListOfFile, reader); //reading, printing, adding

            Console.WriteLine();

            Console.WriteLine("Source of the output file:\n");
            namesListOfFile.Sort(); //sorting
            WriteToFile(namesListOfFile, outputFile); //writting
            PrintingFile(outputFile); // printing
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
            Console.WriteLine();
            Console.WriteLine("Good Bye");
            Console.WriteLine();
        }
    }

    private static void PrintingFile(string outputFile)
    {
        //priting the output data file, with the sorted strings
        StreamReader reader = new StreamReader(outputFile);
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
        }
    }

    private static void WriteToFile(List<string> names, string outputFile)
    {
        //writting the sorted List to the output file
        StreamWriter writer = new StreamWriter(outputFile);
        using (writer)
        {
            for (int index = 0; index < names.Count; index++)
            {
                writer.WriteLine(names[index]);        
            }
        }
    }

    private static void ReadingFile(List<string> namesListOfFile, StreamReader reader)
    {
        //reading the input file, also we are printing 
        //the source and adding to the List each string
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                namesListOfFile.Add(line);
                line = reader.ReadLine();
            }
        }
    }
}

