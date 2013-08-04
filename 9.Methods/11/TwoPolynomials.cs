//Write a method that adds two polynomials. 
//Represent them as arrays of their coefficients
//as in the example below: x2 + 5 = 1x2 + 0x + 5 

using System;

class TwoPolynomials
{
    //selecting polinomial array
    static int[] AddPolynomials(int [] array)
    {
        for (int indexer = array.Length-1; indexer >= 0; indexer--)
        {
            Console.Write("x^{0} =", indexer);
            array[indexer] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    //printing
    static int[] PrintPoly(int[] array)
    {
        for (int indexer = array.Length - 1; indexer >= 0; indexer--)
        {
            if (array[indexer] == 0)
            {
                continue;
            }
            if (indexer == 0)
            {
                Console.Write(array[indexer]);
            }
            else if (indexer == 1)
            {
                Console.Write("{0} * x", array[indexer]);
            }
            else
            {
                Console.Write("{0} * x^{1}", array[indexer], indexer);
            }
            if (indexer > 0)
            {
                Console.Write(" + ");
            }
        }
        Console.WriteLine();
        return array;
    }

    //sum
    static int[] SumPolinomials(int[] polinomialCoef, int[] firstPoly, int []secondPoly)
        {      
            int minLength = Math.Min(firstPoly.Length, secondPoly.Length);
            int maxLength = Math.Max(firstPoly.Length, secondPoly.Length);
            int [] result = new int [maxLength];

            for (int indexer = maxLength - 1; indexer >= 0; indexer--)
            {
                if (indexer < minLength)
                {
                    result[indexer] = firstPoly[indexer] + secondPoly[indexer];
                }
                else if (indexer > firstPoly.Length - 1)
                {
                    result[indexer] = secondPoly[indexer];
                }
                else if (indexer > secondPoly.Length - 1)
                {
                    result[indexer] = firstPoly[indexer];
                }
            } 
            return result;
        }
   
    //Extend the program to support also subtraction and multiplication of polynomials.

    //subtraction
    static void SubPolinomials(int[] firstPoly, int[] secondPoly)
    {
        int minLength = Math.Min(firstPoly.Length, secondPoly.Length);
        int maxLength = Math.Max(firstPoly.Length, secondPoly.Length);
        int[] resultS = new int[maxLength];
        for (int indexer = maxLength - 1; indexer >= 0; indexer--)
        {
            if (indexer < minLength)
            {
                resultS[indexer] = firstPoly[indexer] - secondPoly[indexer];
            }
            else if (indexer > firstPoly.Length - 1)
            {
                resultS[indexer] = (-secondPoly[indexer]);
            }
            else if (indexer > secondPoly.Length - 1)
            {
                resultS[indexer] = firstPoly[indexer];
            }
        }
        PrintPoly(resultS);
    }

    //multiplication
    static void MultiPolinomials(int[] firstPoly, int[] secondPoly)
    {
        int[] resultM = new int[firstPoly.Length + secondPoly.Length];

        for (int indexer = firstPoly.Length - 1; indexer >= 0; indexer--)
        {
            for (int jugger = secondPoly.Length - 1; jugger >= 0; jugger--)
            {
                resultM[indexer + jugger] = firstPoly[indexer] * secondPoly[jugger];

                if (resultM[indexer + jugger] == 0)
                {
                    continue;
                }
                if (indexer + jugger == 0)
                {
                    Console.Write(resultM[indexer + jugger]);
                }
                else if (indexer + jugger == 1)
                {
                    Console.Write("{0} * x", resultM[indexer + jugger]);
                }
                else
                {
                    Console.Write("{0} * x^{1} ", resultM[indexer + jugger], indexer + jugger);
                }
                if (indexer + jugger > 0)
                {
                    Console.Write(" + ");
                }
            }
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Input the lenght of polynomial: ");
        int sizeOfPoly = int.Parse(Console.ReadLine());
        int[] polynomial = new int[sizeOfPoly];
        int[] firstPoly = AddPolynomials(polynomial);
        int[] secondPoly = AddPolynomials(polynomial);
        PrintPoly(firstPoly);
        PrintPoly(secondPoly);
        PrintPoly(SumPolinomials(polynomial, firstPoly, secondPoly));

        //Task 12
        SubPolinomials(firstPoly, secondPoly);
        MultiPolinomials(firstPoly, secondPoly);
    }
}

