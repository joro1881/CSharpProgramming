//Write a program that enters file name along with its full file path
//(e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
//Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all
//possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Text;

class FullFilePathEntered
{
    static void Main()
    {
        Console.WriteLine("Please enter file name and it's path");
        string name = Console.ReadLine();
        string path = Console.ReadLine();

        //I am using the info at msdn.microsoft.com/en-us/library/ms143368.aspx

        try
        {
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }
        catch (ArgumentException AE)
        {
            Console.WriteLine(AE.Message);
        }
        catch (FileNotFoundException FNFE)
        {
            Console.WriteLine(FNFE.Message);
        }
        catch (PathTooLongException PTLE)
        {
            Console.WriteLine(PTLE.Message);
        }
        catch (DirectoryNotFoundException DNFE)
        {
            Console.WriteLine(DNFE.Message);
        }
        catch (IOException IOE)
        {
            Console.WriteLine(IOE.Message);
        }
        catch (UnauthorizedAccessException UAE)
        {
            Console.WriteLine(UAE.Message);
        }
        catch (NotSupportedException NSE)
        {
            Console.WriteLine(NSE.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}

