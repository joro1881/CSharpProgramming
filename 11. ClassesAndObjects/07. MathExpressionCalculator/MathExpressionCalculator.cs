using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

public class MathExpressionCalculator
{
    public static List<char> arithmeticOperations = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln" };

    //method for converting to reverse polish notation
    //I make some changes from the video
    //The method for getting the tokens is not necessary
    //I just merge them...

    public static Queue<string> ConvertToRPN(string tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();

        var number = new StringBuilder();

        for (int i = 0; i < tokens.Length; i++)
        {
            //here we took the number and add it to the queue
            if (tokens[i] == '-' && (i == 0 || tokens[i - 1] == ',' || tokens[i - 1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(tokens[i]) || tokens[i] == '.')
            {
                number.Append(tokens[i]);
            }
            else if (!char.IsDigit(tokens[i]) && tokens[i] != '.' && number.Length != 0)
            {
                double numberToQueue;
                if (double.TryParse(number.ToString(), out numberToQueue))
                {
                    queue.Enqueue(number.ToString());
                    number.Clear();
                }
                i--;
            }
            //

        // here we add to the stack the functions
            else if (i + 1 < tokens.Length && tokens.Substring(i, 2).ToLower() == "ln")
            {
                stack.Push("ln");
                i++;
            }
            else if (i + 2 < tokens.Length && tokens.Substring(i, 3).ToLower() == "pow")
            {
                stack.Push("pow");
                i += 2;
            }
            else if (i + 3 < tokens.Length && tokens.Substring(i, 4).ToLower() == "sqrt")
            {
                stack.Push("sqrt");
                i += 3;
            }
            //

        //checking for brackets and add from the stack to the queue
            else if (tokens[i] == ',')
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets or function separator");
                }

                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                    // if not working => you may need to pop the "("
                }
            }
            //

        //here we are adding operations to the queue
            else if (arithmeticOperations.Contains(tokens[i]))
            {
                // if not working => refactor logic for currentToken

                while (stack.Count != 0 && arithmeticOperations.Contains(stack.Peek()[0]) && Precedence(tokens[i].ToString()) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Push(tokens[i].ToString());
            }
            //

        //add left bracket to the stack
            else if (tokens[i].ToString() == "(")
            {
                stack.Push("(");
            }
            //

        //checking again the bracekts in the expresion
            //adding from the stack to the queue
            else if (tokens[i].ToString() == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets position");
                }

                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Pop();

                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            //
            else
            {
                throw new ArgumentException("Invalid expression");
            }
        }

        //adds the remain digits to the queue as a number
        if (number.Length != 0)
        {
            queue.Enqueue(number.ToString());
        }
        //

        //while there is brackets left in the stack - error
        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position");
            }
            //if theres no brackets add from stack to queue
            queue.Enqueue(stack.Pop());
        }

        return queue;
    }

    public static int Precedence(string arithmeticOperator)
    {
        // in this method we set the rank of importance of the operators
        // latter we are going to need the rank in the actions
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public static void PutInvariantCulture()
    {
        //we need this to set the ',' and '.' of the user
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }

    public static double GetResultFromRPN(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();

        while (queue.Count != 0)
        {
            //we are getting the first element of the queue
            string currentToken = queue.Dequeue();
            double number;

            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }

            //arithmetic operations of the numbers
            else if (arithmeticOperations.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                //summary
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue + secondValue);
                }
                //

                //subtraction
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue - firstValue);
                }
                //

                //multiplication
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue * firstValue);
                }
                //

                //division
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue / firstValue);
                }
                //

                //functions:

                    //POW
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Pow(secondValue, firstValue));
                }
                //SQRT
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Sqrt(value));
                }
                //Logarithm
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Log(value));
                }
            }
        }

        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression");
        }
    }

    public static void StartCalculating()
    {
        string input = Console.ReadLine().Trim();

        while (input.ToLower() != "end")
        {
            try
            {
                string trimmedInput = input.Replace(" ", string.Empty);
                var revPolishNotation = ConvertToRPN(trimmedInput);
                var finalResult = GetResultFromRPN(revPolishNotation);
                Console.WriteLine(finalResult);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            input = Console.ReadLine().Trim();
        }
    }

    public static void Main()
    {
        PutInvariantCulture();
        Console.WriteLine("***Math Expression Calculator***");
        Console.WriteLine();
        Console.WriteLine();
        StartCalculating();
    }
}