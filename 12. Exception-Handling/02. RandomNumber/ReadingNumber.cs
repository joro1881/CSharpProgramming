//Write a method ReadNumber(int start, int end) that enters an integer number
//in given range [start…end]. If an invalid number or non-number text is entered,
//the method should throw an exception. Using this method write a program that 
//enters 10 numbers:
//            a1, a2, … a10, such that 1 < a1 < … < a10 < 100
using System;

class ReadingNumber
{
    //nothing difficult in the task
    // we have one loop in TRY, one method for reading the number
    //catch signature for exceptions and finally
    static void Main()
    {
        int start = 1;
        int end = 100;
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter a number in the range [1-100]");
                ReadNumber(start, end);
            }
        }
        catch (FormatException fe)
        {
            Console.WriteLine("Not a number\n" + fe.Message);
        }
        catch (IndexOutOfRangeException re)
        {
            Console.WriteLine("NumberOutOfRange\n" + re.Message);
        }
        catch (OverflowException of)
        {
            Console.WriteLine("The number is too big\n" + of.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }

    public static void ReadNumber(int start, int end)
    {
        int numberRead = int.Parse(Console.ReadLine());
        if (numberRead < 1 || numberRead > 100)
        {
            throw new IndexOutOfRangeException();
        }
        else if (numberRead > 1 || numberRead < 100)
        {
            Console.WriteLine(numberRead);
        }
    }
}

