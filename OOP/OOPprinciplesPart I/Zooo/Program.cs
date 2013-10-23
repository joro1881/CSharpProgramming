//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat 
//and define useful constructors and methods. 
//Dogs, frogs and cats are Animals. All animals can 
//produce sound (specified by the ISound interface). 
//Kittens and tomcats are cats. All animals are described
//by age, name and sex. Kittens can be only female and 
//tomcats can be only male. Each animal produces a specific sound.
//Create arrays of different kinds of animals and 
//calculate the average age of each kind of animal 
//using a static method (you may use LINQ).

using System;
using Zooo;

class Program
{
    static void Main()
    {
        Dog[] dogs = 
        {
            new Dog("Sharo1",'m',70),
            new Dog("Sharo2",'m',100),
            new Dog("Sharo3",'m',50),
            new Dog("Sharka5",'f',5),
            new Dog("Sharka4",'f',2),
        };

        Cat[] cats = 
        {
            new Tomcat("Kotarak", 25),
            new Cat("Uli4naPrevuzhodna",'m', 35),
            new Kitten("Maca", 19),
            new Cat("Prosharka",'f',45)
        };

        Frog[] frogs = 
        {
            new Frog("blatna",'f',5),
            new Frog("ezerna",'f',1),
            new Frog("krastavi4ar",'m',8),
        };

        foreach (Dog dog in dogs)
        {
            dog.TypeAnimal();
            dog.AnimalSound();
        }

        Console.WriteLine();

        foreach (Cat cat in cats)
        {
            cat.TypeAnimal();
            cat.AnimalSound();
        }

        Console.WriteLine();

        foreach (Frog frog in frogs)
        {
            frog.TypeAnimal();
            frog.AnimalSound();
        }
        Console.WriteLine();
        Console.WriteLine("Average age of : ");
        Console.WriteLine("Cats: {0} ", Animal.Average(cats));
        Console.WriteLine("Dogs: {0} ", Animal.Average(dogs));
        Console.WriteLine("Frogs: {0}", Animal.Average(frogs));
    }
}

