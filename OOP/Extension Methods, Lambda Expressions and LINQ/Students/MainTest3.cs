using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class MainTest3
    {
        static void Main()
        {
              Student[] students = { new Student("George", "Yankov", 23), new Student("Hristo", "Hristov", 28), 
                                   new Student("Stoqn", "Milkov", 29), new Student("Hristofor", "Rusev", 24), 
                                   new Student("Yanislava", "Hadzhiiska", 19),new Student("Konstantin", "Konstantinov", 26)
                               };


            //task 3 
              Console.WriteLine("Task 3");
              var studentsList = from person in students
                                 where person.Name.CompareTo(person.FamillyName) < 0
                                 select person;

              foreach (Student item in studentsList)
              {
                  Console.WriteLine(item);
              }
              Console.WriteLine();
            
            //task 4
            //Write a LINQ query that finds the first name 
            //and last name of all students with age between 18 and 24.
              Console.WriteLine("Task 4");

              var newStudents = from person in students
                                where person.Age >= 18 && person.Age <= 24
                                select new { person1 = person.Name, person2 = person.FamillyName };

              foreach (var item in newStudents)
              {
                  Console.WriteLine(item.person1 + " " + item.person2);
              }
              Console.WriteLine();

            //task 5 
            //Using the extension methods OrderBy() 
            //and ThenBy() with lambda expressions 
            //sort the students by first name and 
            //last name in descending order. Rewrite the same with LINQ.
              Console.WriteLine("Task 5");
              Console.WriteLine("- Lambda expression");
              var studentsOrdered = from person in students
                                    orderby person.Name descending,
                                    person.FamillyName descending
                                    select person;
              foreach (Student item in studentsOrdered)
              {
                  Console.WriteLine(item);
              }
              Console.WriteLine();
              Console.WriteLine("- LINQ expression");

              var newStudentsOrdered = students.OrderByDescending(x => x.Name).ThenBy
                  (x => x.FamillyName);
              foreach (var item in newStudentsOrdered)
              {
                  Console.WriteLine(item);
              }



        }
    }

}
