//Define abstract class Human with first name and last name.
//Define new class Student which is derived from Human and 
//has new field – grade. Define class Worker derived from 
//Human with new property WeekSalary and WorkHoursPerDay 
//and method MoneyPerHour() that returns money earned by 
//hour by the worker. Define the proper constructors and 
//properties for this hierarchy. Initialize a list of 10 
//students and sort them by grade in ascending order 
//(use LINQ or OrderBy() extension method). Initialize a 
//list of 10 workers and sort them by money per hour 
//in descending order. Merge the lists and sort them by first name and last name.

using System;
using System.Collections.Generic;
using SocietySystem;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Ali","Baba", 1),
            new Student("Stoi4o","Kalaram", 2),
            new Student("Kino","Ofnoko", 3),
            new Student("Chok","Ofbok", 9),
            new Student("Kriv","Stuner", 8),
            new Student("Osa","Ela", 5),
            new Student("Kroki","Snaks", 6),
            new Student("Punti","Leiri", 7),
            new Student("Kruk","Kruk", 4),
            new Student("Himba","Luorna", 10)
        };

        Console.WriteLine("Students grades: ");

        foreach (var item in students)
        {
            Console.WriteLine(item.FirstName + " : grade : " + item.Grade);
        }

        students = students.OrderBy(student => student.Grade).ToList();
        Console.WriteLine();
        Console.WriteLine("Sorting...");

        foreach (var item in students)
        {
            Console.WriteLine(item.FirstName + " : grade : " + item.Grade);
        }

        Console.WriteLine();

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Ali","Baba", 50, 1),
            new Worker("Stoi4o","Kalaram", 80, 2),
            new Worker("Kino","Ofnoko", 150, 3),
            new Worker("Chok","Ofbok", 789, 9),
            new Worker("Kriv","Stuner", 1100, 8),
            new Worker("Osa","Ela", 620,5),
            new Worker("Kroki","Snaks", 750,6),
            new Worker("Punti","Leiri", 850, 7),
            new Worker("Kruk","Kruk", 500, 4),
            new Worker("Himba","Luorna", 800, 10)
        };

        Console.WriteLine("Worker's solary is: ");
        foreach (var item in workers)
        {
            Console.WriteLine(item.FirstName + " : Money per Hour : " + item.MoneyPerHour());
        }

        Console.WriteLine();

        workers = workers.OrderBy(worker => worker.MoneyPerHour()).ToList();

        Console.WriteLine("Sorting...");
        foreach (var item in workers)
        {
            Console.WriteLine(item.FirstName + " : Money per Hour : " + item.MoneyPerHour());
        }

        Console.WriteLine();
        Console.WriteLine("Merging the list...");

        var mergedlist = workers.Concat<Human>(students).ToList();
        mergedlist = mergedlist.OrderBy(list => list.FirstName).ThenBy(list => list.LastName).ToList();

        foreach (var item in mergedlist)
        {
            Console.WriteLine(item.FirstName + " " +  item.LastName);
        }
    }
}

