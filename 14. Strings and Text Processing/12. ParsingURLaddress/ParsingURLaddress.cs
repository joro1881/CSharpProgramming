//Write a program that parses an URL address given in the format:
//[protocol]://[server]/[resource]
//and extracts from it the [protocol], [server] and [resource] elements. 
//For example from the URL "http://www.devbg.org/forum/index.php"
//the following information should be extracted:
//        [protocol] = "http"
//        [server] = "www.devbg.org"
//        [resource] = "/forum/index.php"

using System;

class ParsingURLaddress
{
    static void Main()
    {
        string URL = @"http://www.devbg.org/forum/index.php";

        URL = ParsingURL(URL);
        Console.WriteLine();

    }

    private static string ParsingURL(string URL)
    {
        Console.WriteLine("The URL address: \"{0}\"", URL);
        Console.WriteLine();
        //first we find the index of ':'
        int index = 0;
        index = URL.IndexOf(':');

        //after that printing with substring
        Console.WriteLine("Protocol - \"{0}\"", URL.Substring(0, index));
        //deleting the part which was already printed+//
        URL = URL.Replace(URL.Substring(0, index + 3), string.Empty);

        //finding the index of the next '/'
        index = URL.IndexOf('/');
        //printing with substring
        Console.WriteLine("Server - \"{0}\"", URL.Substring(0, index));
        //deleting and that part, leave only the resource
        URL = URL.Replace(URL.Substring(0, index), string.Empty);

        //printing the resource
        Console.WriteLine("Resource - \"{0}\"", URL);

        return URL;
    }
}

