//Write a program that reads an integer number and calculates and prints its square root. 
//If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class InvalidNumber
{
    static void Main()
    {
        // we have TRY with entering the input data and method for square
        //signature of catch for exceptions and finally
        try
        {
            Console.WriteLine("Please set an integer number for calculating: ");
            double number = double.Parse(Console.ReadLine());
            SquareRoot(number);
        }
        catch (FormatException fe)
        {
            Console.WriteLine("Invalid format\n" + fe.Message);
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too big!");
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Invalid number! Square root can NOT calculating negative number!");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }

    public static void SquareRoot(double a)
    {
        if (a < 0)
        {
            throw new ArithmeticException();
        }
        double squareRoot = Math.Sqrt(a);
        Console.WriteLine(squareRoot);
    }
}

