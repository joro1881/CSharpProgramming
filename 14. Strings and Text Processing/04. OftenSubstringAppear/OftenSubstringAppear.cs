//Write a program that finds how many times a substring is
//contained in a given text (perform case insensitive search).
//Example: The target substring is "in". The text is as follows:
//We are living in an yellow submarine. We don't have anything 
//else. Inside the submarine is very tight. So we are drinking
//all the day. We will move out of it in 5 days.
//The result is: 9.
using System;
using System.IO;

class OftenSubstringAppear
{
    static void Main()
    {
        try
        {
            string txtFile = @"..\..\text.txt";
            CheckingSubstring(txtFile);
        }
        catch (FileNotFoundException FNFE)
        {
            Console.WriteLine(FNFE.Message);
        }
        catch (FileLoadException FLE)
        {
            Console.WriteLine(FLE.Message);
        }
        catch (IOException IOE)
        {
            Console.WriteLine(IOE.Message);
        }
    }

    private static void CheckingSubstring(string txtFile)
    {
        //using the text-files processing from the last lesson
        //we have for cycle with Substring logic for finding "in"
        //one counter to check every appearance
        StreamReader reader = new StreamReader(txtFile);
        using (reader)
        {
            int count = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line.Substring(i, 2).ToLower() == "in")
                    {
                        count++;
                    }
                }
                line = reader.ReadLine();
            }
            Console.WriteLine(count);
        }
    }
}

