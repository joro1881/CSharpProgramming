//Write a program that concatenates two text files into another text file.

using System;
using System.IO;


namespace Concat
{
    public class ConcatenatesTwoText
    {
        static void Main()
        {
            string fileZeros = @"..\..\Zeros.txt";
            string fileSingles = @"..\..\Singles.txt";
            string binary = @"..\..\binary.txt";
            ConcatenatesTwoFiles(fileZeros, fileSingles, binary);
            PrintingFile(binary);
        }

        //method
        private static void ConcatenatesTwoFiles(string fileZeros, string fileSingles, string newFile)
        {
            //first we are defying  two readers and one writer
            StreamReader readerSingles = new StreamReader(fileSingles);
            StreamReader readerZeros = new StreamReader(fileZeros);
            StreamWriter writer = new StreamWriter(newFile);
            using (writer)
            {
                //now we are writting to the new file
                using (readerZeros)
                {
                    //getting the information from the first file
                    string line = readerZeros.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = readerZeros.ReadLine();
                    }
                }
                using (readerSingles)
                {
                    //getting the information from the second file
                    string line = readerSingles.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(line);
                        line = readerSingles.ReadLine();
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
}

