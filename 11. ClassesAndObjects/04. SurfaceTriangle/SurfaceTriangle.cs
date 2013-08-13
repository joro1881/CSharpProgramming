//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class SurfaceTriangle
{
    static byte choice;

    static void Main()
    {
        Menu();
        if (choice == 1)
        {
            SurfaceBySideAltitude();
        }
        if (choice == 2)
        {
            SurfaceByThreeSides();
        }
        if (choice == 3)
        {
            SurfaceByTwoSidesAngle();
        }
    }

    //method for calc surface of triangle(3)
    private static void SurfaceByTwoSidesAngle()
    {
        Console.WriteLine(
            "Please set value for two sides and angle between them,\n they must be positive");

        int sideA;
        int sideB;
        float angle;
        double surface;

        //def input data
        do
        {
            Console.WriteLine("Side A: ");
        } while (!int.TryParse(Console.ReadLine(), out sideA));
        do
        {
            Console.WriteLine("Side B: ");
        } while (!int.TryParse(Console.ReadLine(), out sideB));
        do
        {
            Console.WriteLine("Angle: ");
        } while (!float.TryParse(Console.ReadLine(), out angle));

        if (sideA <= 0 || sideB <= 0 || angle <= 0)
        {
            Console.WriteLine("Wrong input, try again");
            SurfaceByTwoSidesAngle();
        }
        else
        {
            //logic
            surface = ((sideA * sideB) / 2) * Math.Sin((Math.PI*angle)/180);
            Console.WriteLine("Surface : {0}cm^2", surface);
        }
    }

    //method for calc surface of triangle(2)
    private static void SurfaceByThreeSides()
    {
        Console.WriteLine(
            "Please set value for three sides,\n they must be positive");

        int sideA;
        int sideB;
        int sideC;
        float surface;

        //def input data
        do
        {
            Console.WriteLine("Side A: ");
        } while (!int.TryParse(Console.ReadLine(), out sideA));
        do
        {
            Console.WriteLine("Side B: ");
        } while (!int.TryParse(Console.ReadLine(), out sideB));
        do
        {
            Console.WriteLine("Side C: ");
        } while (!int.TryParse(Console.ReadLine(), out sideC));

        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            Console.WriteLine("Wrong input, try again");
            SurfaceByThreeSides();
        }
        else
        {
            //logic
            Console.WriteLine("We will use the Heron's formula");
            float perimetur = (sideA + sideB + sideC)/2;
            surface = perimetur*(perimetur - sideA)*(perimetur - sideB)*(perimetur - sideC);
            Console.WriteLine("Surface : {0}cm^2", Math.Sqrt(surface));
        }
    }

    //method for calc surface of triangle(1)
    private static void SurfaceBySideAltitude()
    {
        Console.WriteLine(
            "Please set value for side and altitude,\n they must be positive");

        int side;
        int high;
        float surface;

        //def input data
        do
        {
            Console.WriteLine("Side: ");
        } while (!int.TryParse(Console.ReadLine(), out side));
        do
        {
            Console.WriteLine("High: ");
        } while (!int.TryParse(Console.ReadLine(), out high));

        if (side <= 0 || high <= 0)
        {
            Console.WriteLine("Wrong input, try again");
            SurfaceBySideAltitude();
        }
        else
        {
            //logic
            surface = (float)(side * high) / 2;
            Console.WriteLine("Surface : {0}cm^2", surface);
        }
    }

    //menu for good user interface :) 
    private static byte Menu()
    {
        Console.WriteLine("Please set a way of calculating: ");
        Console.WriteLine();
        Console.WriteLine("1. Surface by side and an altitude to it");
        Console.WriteLine("2. Surface by three sides");
        Console.WriteLine("3. Surface by two sides and an angle between them");
        Console.WriteLine("0. Exit");

        do
        {
        } while (!byte.TryParse(Console.ReadLine(), out choice));

        switch(choice)
        {
            case 0:
                choice = 0;
                break;
            case 1:
                choice = 1;
                break;
            case 2:
                choice = 2;
                break;
            case 3:
                choice = 3;
                break;
            default:
                {
                    Console.WriteLine("Wrong set, try again!");
                    Menu();
                }
                break;
        }
        return choice;
    }
}

