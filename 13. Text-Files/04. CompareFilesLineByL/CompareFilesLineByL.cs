//Write a program that compares two text files line by line
//and prints the number of lines that are the same and the 
//number of lines that are different. Assume the files have
//equal number of lines.

using System;
using System.IO;

class CompareFilesLineByL
{
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

    static void Main()
    {
        string original = @"..\..\Original.txt";
        string compared = @"..\..\Compared.txt";
        StreamReader readerOriginal = new StreamReader(original);
        StreamReader readerCompared = new StreamReader(compared);
        CompareLines(original, compared, readerOriginal, readerCompared);
        PrintingFile(original);
        Console.WriteLine();
        PrintingFile(compared);
    }

    private static void CompareLines(string original, string compared, StreamReader readerOriginal, StreamReader readerCompared)
    {
        //open the original file
        using (readerOriginal)
        {
            //open the file for comparing
            using (readerCompared)
            {
                string lineOri = readerOriginal.ReadLine();
                string lineCom = readerCompared.ReadLine();
                int countSame = 0;
                int countDiff = 0;
                //logic with two counters
                while (lineCom != null)
                {
                    if (lineOri == lineCom)
                    {
                        countSame++;
                    }
                    else countDiff++;
                    lineOri = readerOriginal.ReadLine();
                    lineCom = readerCompared.ReadLine();
                }
                Console.WriteLine("The number of same lines: {0}", countSame);
                Console.WriteLine("The number of diffrent lines: {0}", countDiff);
            }
        }
    }
}

