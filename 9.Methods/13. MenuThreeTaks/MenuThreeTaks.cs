//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//        Create appropriate methods.
//        Provide a simple text-based menu for the user to choose which task to solve.
//        Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0


using System;

class MenuThreeTaks
{
    //Reversing digits of a number;
    static decimal DigitsReversed(decimal number)
    {
        string reversed = number.ToString();
        char[] array = reversed.ToCharArray();
        Array.Reverse(array);
        string str = new string(array);
        number = decimal.Parse(str);
        return number;
    }
    
    //Solving linear equation a*x + b = 0;
    static double? Equation(double a, double b)
    {
        double? x = null;
        if (a == 0)
        {
            Console.WriteLine("a should not be equal to 0\nError!");
        }        
        if (a != 0 )
        {
            x = (-b) / a;
            return x;
        }
        else if (b == 0)
        {
            return x = 0;
        }
        return x;
    }

    //Calculates the average of a sequence of integers;
    static double AverageOfSeq(int[] array)
    {
        double result;
        double sum = 0;
            for (int indexer = 0; indexer < array.Length; indexer++)
			{
                sum += array[indexer];		 
			}
            result = sum / array.Length;
        return result;
    }

    //Menu
    static void Menu()
    {
        Console.WriteLine("Make a choice from the menu: ");
        string str = Console.ReadLine();
        int input;
        bool parseSuccess = int.TryParse(str, out input);
        if(parseSuccess)
        {
            switch(input)
            {
                //Reversing digits of a number;
                case 0: Console.WriteLine("Have a nice day!!!");
                    break;
                case 1:
                    Console.WriteLine("Choose a non-negative decimal number for reversing:");
                    string data = Console.ReadLine();
                    decimal number;
                    bool parseSuc = decimal.TryParse(data, out number);
                    if (parseSuc)
                    {
                        if (number >= 0) { Console.WriteLine(DigitsReversed(number)); }
                        else
                        {
                            Console.WriteLine("Wrong input, try again: ");
                            Menu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, try again: ");
                        Menu();
                    }
                    break;

                //Solving linear equation a*x + b = 0;
                case 3:
                        Console.WriteLine("Choose a and b for solving equation:\nTIP:a must be !=0 !!!");
                    string data1 = Console.ReadLine();
                    double a;
                    double b;
                    bool parsSuc = double.TryParse(data1, out a);
                    if (parsSuc)
                    {
                        if (a != 0)
                        {
                            string data2 = Console.ReadLine();
                            bool parsS = double.TryParse(data2, out b);
                            if (parsS)
                            {
                                Console.WriteLine("({0})*x + ({1}) = 0\nx = {2}", a, b, Equation(a, b));
                            }
                            else
                            {
                                Console.WriteLine("Wrong input, try again: ");
                                Menu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, try again: ");
                            Menu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, try again: ");
                        Menu();
                    }
                    break;

                //Calculates the average of a sequence of integers;
                case 2:
                    Console.WriteLine("Choose lengh for sequence:\nTIP: sequence > 0 !!!");
                    string massive = Console.ReadLine();
                    int size;
                    bool paSuccess = int.TryParse(massive, out size);
                    if (paSuccess)
                    {
                        if (size > 0)
                        {
                            Random rand = new Random();
                            int min = 0;
                            int max = 15;
                            int[] array = new int[size];
                            for (int indexer = 0; indexer < array.Length; indexer++)
                            {
                                array[indexer] = rand.Next(min, max);
                            }
                            foreach (var item in array)
                            {
                                Console.Write("{0} ", item);
                            }
                            Console.WriteLine();
                            Console.WriteLine("The average of a sequence is: {0}", AverageOfSeq(array));
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, try again: ");
                            Menu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, try again: ");
                        Menu();
                    }
                    break;
                default:
                    Console.WriteLine("Wrong input, try again: ");
                    Menu();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Wrong input, try again: ");
            Menu();
        }
    }

    static void Main()
    {
        PrintMenu();
        Menu();
    }

    private static void PrintMenu()
    {
        Console.WriteLine("*================ MENU ==================*");
        Console.WriteLine("* 1. Reverse digits of number!            *");
        Console.WriteLine("* 2. Calculates the average of a sequence *");
        Console.WriteLine("* 3. Solves a linear equation             *");
        Console.WriteLine("* 0. EXIT                                 *");
        Console.WriteLine("*=========================================*");
    }
}

