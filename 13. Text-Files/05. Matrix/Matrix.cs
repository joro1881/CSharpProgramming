//Write a program that reads a text file containing a square matrix of numbers 
//and finds in the matrix an area of size 2 x 2 with a maximal sum of its 
//elements. The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space. The output 
//should be a single number in a separate text file. Example:
//4
//2 3 3 4
//0 2 3 4 --------> 17
//3 7 1 2
//4 3 3 2

using System;
using System.IO;

class Matrix
{
    static int[,] matrix;
    static int summary;

    static void Main()
    {
        try
        {
            string inputMatrix = @"..\..\matrix.txt";
            string outputMatrix = @"..\..\outputMatrix.txt";

            StreamReader reader = new StreamReader(inputMatrix);
            ReadingInput(reader);

            PrintMatrix();
            MaxSummaryOfMatrix_2x2();
            WriteToOutputDir(summary, outputMatrix);
            ReadingFile(outputMatrix);
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

    private static void ReadingFile(string File)
    {
        //printing the source of the second file
        Console.WriteLine("The output file, with the number of summary");
        StreamReader reader = new StreamReader(File);
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

    private static void WriteToOutputDir(int sum, string output)
    {
        //writting to the second file, the calculations of the first
        StreamWriter writer = new StreamWriter(output);
        using (writer)
        {
            writer.WriteLine(sum);
        }
    }

    private static void MaxSummaryOfMatrix_2x2()
    {
        //method for finding the best summary of 2x2 matrix
        summary = int.MinValue;
        int sum;
        int bestRow = 0;
        int bestCol = 0;

        for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
            {
                //method for summary 2x2 matrix
                sum = Sum(matrix, rows, cols);

                if (sum >= summary)
                {
                    //logic for finding the best summary
                    summary = sum;
                    bestRow = rows;
                    bestCol = cols;
                }
            }
        }
        Console.WriteLine("The maximum sum of 2x2 matrix is: {0}", summary);
        //printing metod for sub matrix
        PrintSubMatrix(matrix, bestRow, bestCol);
    }

    private static void PrintSubMatrix(int[,] matrix, int bestRow, int bestCol)
    {
        //printing metod for sub matrix
        for (int index = 0; index < 2; index++)
        {
            for (int jugger = 0; jugger < 2; jugger++)
            {
                Console.Write("{0} ", matrix[bestRow + index, bestCol + jugger]);
            }
            Console.WriteLine();
        }
    }

    private static int Sum (int[,] matrix, int rows, int cols)
    {
        //method for sum 2x2 matrix size
        int endSum = 0;
        for (int index = 0; index < 2; index++)
        {
            for (int jugger = 0; jugger < 2; jugger++)
            {
                endSum += matrix[rows + index, cols + jugger];
            }
        }
        return endSum;
    }

    private static void PrintMatrix()
    {
        Console.WriteLine("Matrix: ");
        //standard logic for printing matrix 
        for (int index = 0; index < matrix.GetLength(0); index++)
        {
            for (int jugger = 0; jugger < matrix.GetLength(1); jugger++)
            {
                Console.Write("{0} ", matrix[index, jugger]);
            }
            Console.WriteLine();
        }
    }

    private static void ReadingInput(StreamReader reader)
    {
        //reading the input data changing it to int matrix
        using (reader)
        {
            string line = reader.ReadLine();
            int size = int.Parse(line);
            matrix = new int[size, size];
            int row = 0;
            line = reader.ReadLine();
            while (line != null)
            {
                //method for inverting to int matrix
                SetMatrix(line, row);
                row++;
                line = reader.ReadLine();
            }
        }
    }

    private static void SetMatrix(string line, int row)
    {
        //method for inverting to int matrix
        char[] separator = {' '};
        //first we are spliting and removing the non needed spaces :) 
        string[] sequence = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        for (int index = 0; index < sequence.Length; index++)
        {
            matrix[row, index] = int.Parse(sequence[index]);
        }
    }
}

