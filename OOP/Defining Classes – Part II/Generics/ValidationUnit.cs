using System;

namespace Generics
{
    public class ValidationUnit
    {
        static void Main()
        {
            GenericList<int> test = new GenericList<int>();
            test.AddElement(5);
            test.AddElement(6);
            test.AddElement(7);
            test.AddElement(8);
            test.AddElement(9);

            //testing method add
            Console.WriteLine(test);
            //testing insert method
            Console.WriteLine("Insert element 2 at position 4");
            test.InsertElement(4, 2);
            Console.WriteLine(test);
            //testing method remove
            Console.WriteLine("Removing element at pos 5");
            test.RemoveAtIndex(5);
            Console.WriteLine(test);
            int result = test.AccessElement(3);
            Console.WriteLine("Accessing element at index 3: ");
            Console.WriteLine(result);
            Console.WriteLine("Finding element by value '0': ");
            Console.WriteLine(test.FindElementByValue(0));

            Console.WriteLine("Clear!");
            test.ClearingList();
            Console.WriteLine(test);
            Console.WriteLine();
            Console.WriteLine("Doubling the size:");
            for (int i = 1; i < 15; i++)
            {
                test.AddElement(i);
            }
            //test.AddElement(1);
            Console.WriteLine(test);
            //testing min max
            Console.WriteLine("Biggest, smallest: ");
            Console.WriteLine(test.Max<int>());
            Console.WriteLine(test.Min<int>());
        }
    }
}
