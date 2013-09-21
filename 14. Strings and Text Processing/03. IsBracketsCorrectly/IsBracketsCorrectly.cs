//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;

class IsBracketsCorrectly
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Set expression, please: ");
            string input = Console.ReadLine();
            //string input = "((a+b)/5-d)";
            //string input = ")(a+b))";
            CheckingBrackets(input);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("There is no expression, please try again: ");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("There is no brackets in the expression");
        }
        finally
        {
            Console.WriteLine("Good Bye");
        }
    }

    private static void CheckingBrackets(string data)
    {
        //my logic is with counters for left and right
        // some if/else if logic to compare them and fight the incorectivity
        int leftBracket = 0;
        int rightBracket = 0;
        foreach (char item in data)
        {
            if (item == '(')
            {
                leftBracket++;
            }
            if (item == ')')
            {
                rightBracket++;
            }
        }

        if (leftBracket == rightBracket)
        {
            Console.WriteLine("Correct expresion: {0}", data);
        }
        else if (leftBracket > rightBracket)
        {
            Console.WriteLine("Incorrect expresion: {0}", data);
            Console.WriteLine("There are missing right bracket/s");
        }
        else if (leftBracket < rightBracket)
        {
            Console.WriteLine("Incorrect expresion: {0}", data);
            Console.WriteLine("There are missing left bracket/s");
        }
        if (leftBracket == 0 && rightBracket == 0)
        {
            throw new ArgumentException();
        }
        if (data == string.Empty)
        {
            throw new ArgumentNullException();
        }
    }
}

