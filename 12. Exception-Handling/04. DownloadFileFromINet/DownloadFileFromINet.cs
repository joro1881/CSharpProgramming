//Write a program that downloads a file from Internet
//(e.g. www.devbg.org/img/Logo-BASD.jpg) and stores
//it the current directory. Find in Google how to download 
//files in C#. Be sure to catch all exceptions and to free 
//any used resources in the finally block.

using System;
using System.Net;

class DownloadFileFromINet
{
    static void Main()
    {
        // we have some work with namespace Net and webclient class
        WebClient webClient = new WebClient();

        try
        {
            //downloading file from internet
            //first argument is URL from which we will procced
            //second is the name with which we will save it on the comp
            webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "logo.jpg");
        }
            //signature of exceptions specified for webclient class
        catch(ArgumentNullException ANE)
        {
            Console.WriteLine(ANE.Message);
        }
        catch(WebException WE)
        {
            Console.WriteLine(WE.Message);
        }
        catch(NotSupportedException NSE)
        {
            Console.WriteLine(NSE.Message);
        }
        finally
        {
            webClient.Dispose();
            Console.WriteLine("Good Bye");
        }
    }
}

