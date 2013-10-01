using System;

namespace _01.MobilePhone
{

//    Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
//Create an instance of the GSM class.
//Add few calls.
//Display the information about the calls.
//Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//Remove the longest call from the history and calculate the total price again.
//Finally clear the call history and print it.

    class GSMCallHistoryTest
    {
        static public void Main2()
        {
            //create a GSM instance
            Battery battery = new Battery("helolModel", 1500, 1000, BatteryType.LiIon);
            Display display = new Display("100x85", 256);
            GSM tel = new GSM("s400", "Samsung", 500, "Rosen", battery, display);

            //adding calls
            tel.AddCall(DateTime.Now, "0884 667 697", 346);
            tel.AddCall(DateTime.Now.AddHours(6), "0884 789 567", 200);
            tel.AddCall(DateTime.Now.AddDays(1), "0884 667 697", 100);
            tel.AddCall(DateTime.Now.AddHours(10), "0884 789 567", 500);
            tel.AddCall(DateTime.Now.AddMonths(1).AddHours(10), "0884 667 697", 700);

            //printing
            Console.ForegroundColor = ConsoleColor.Gray;
            tel.Print();
            Console.WriteLine("Total price of the calls : {0}eu : 0.37eu for minute\n", tel.CalculateCalls(0.37));
            tel.DeletingCall("0884 667 697", 700);
            tel.Print();
            Console.WriteLine("Total price of the calls : {0}eu : 0.37eu for minute\n", tel.CalculateCalls(0.37));
            tel.ClearHistory();
            Console.WriteLine("Cleared history: ");
            tel.Print();
        }
    }
}
