//Write a program that reads from the console a string of maximum 20 characters.
//If the length of the string is less than 20, the rest of the characters should
//be filled with '*'. Print the result string into the console.

using System;
using System.Text;

class String20Characters
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please input string of data 20 characters: ");
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input);
            CheckingString(sb);
        }
        catch (ArgumentOutOfRangeException AOORE)
        {
            Console.WriteLine(AOORE.Message);
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

    private static void CheckingString(StringBuilder data)
    {
        char[] array = new char[20];
        //i used one array of 20 characters to compare with the input data
        //after that i can check it and throw exceptions

        if(data.Length > array.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (data.Length < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (data.Length == 0)
        {
            throw new ArgumentNullException();
        }
        //when the string is with desire length we can proccesing
        if (data.Length < array.Length && data.Length > 0)
        {
            //with cycle I append * symbol till we fill the desire
            //length of the input string
            for (int i = data.Length; i < array.Length; i++)
            {                
                data.Append('*');
            }
        } 
        //printing the string and the length (for 20 symbols is 19, because first is
        //with index 0)
            Console.WriteLine(data);
            Console.WriteLine(data.ToString().LastIndexOf('*')); 
    }
}

