//Write a method that asks the user for his name and prints “Hello, <name>”
//(for example, “Hello, Peter!”). Write a program to test this method.

using System;
using System.Linq;

class HelloName
{
    static string PrintName()
    {
        Console.WriteLine("Please share your name with us: ");
        string YourName = Console.ReadLine();        
        return YourName;
    }
    static void TestName(string str)
    {
        bool check = str.All(Char.IsLetter);
        if (check)
        {
            Console.WriteLine("Hello, {0}!", str);
        } 
        else
        {
            Console.WriteLine("We don't believe that word is a name!?");
            Main();
        }
    }
        static void Main()
        {
            TestName(PrintName());
        }
}

