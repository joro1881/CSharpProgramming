using System;
using _01.MobilePhone;
//Write a class GSMTest to test the GSM class:
//Create an array of few instances of the GSM class.
//Display the information about the GSMs in the array.
//Display the information about the static property IPhone4S.

class GSMTest
{
    static void Main()
    {
        //creating array of GSM phones, adding info about them
        Console.WriteLine("Mobile phones: ",  Console.ForegroundColor = ConsoleColor.Red);
        GSM[] telephones = new GSM[3];
        Console.ForegroundColor = ConsoleColor.Gray;
        Battery battery = new Battery("helolModel", 1500, 1000, BatteryType.LiIon);
        Display display = new Display("100x85", 256);

        GSM phoneOne = new GSM("s400", "Samsung", 500, "Rosen", battery, display);
        GSM phoneTwo = new GSM("Duos", "Samsung", 500, "Joro", battery, display);
        GSM phoneThree = new GSM("s800", "Samsung", 500, "Tanq", battery, display);

        telephones[0] = phoneOne;
        telephones[1] = phoneTwo;
        telephones[2] = phoneThree;

        //print the info for each phone from the array
        for (int i = 0; i < telephones.Length; i++)
        {
            Console.WriteLine(telephones[i]);
        }

        Console.WriteLine(GSM.IPhone4S.Model);
        Console.WriteLine(GSM.IPhone4S.Manufacturer);
        Console.WriteLine("\nHistory information: \n",
        Console.ForegroundColor = ConsoleColor.Red);
        //go to next Test.cs class
        GSMCallHistoryTest.Main2();
    }
}


