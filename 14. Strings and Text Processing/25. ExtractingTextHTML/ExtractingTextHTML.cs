//Write a program that extracts from given HTML 
//file its title (if available), and its body 
//text without the HTML tags. Example:
//<html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skillful .NET software engineers.</p></body>
//</html>

using System;

class ExtractingTextHTML
{
    static void Main()
    {
        string str = @"<html><head><title>News</title></head><body><p><a href=""
            http://academy.telerik.com"">Telerik Academy</a>aims to provide free
            real-world practical training for young people who want to turn 
            intoskillful .NET software engineers.</p></body></html>";

        int bracket = str.IndexOf('>');
        while (bracket > -1)
        {
            //like we was using that logic Substring,lenght,brackets
            //in tasks before
            if (bracket < str.Length - 1 && str[bracket + 1] != '<')
            {
                int nextOpeningIndex = str.IndexOf('<', bracket);
                int textLength = nextOpeningIndex - bracket - 1;
                Console.WriteLine(str.Substring(bracket + 1, textLength));
            }
            bracket = str.IndexOf('>', bracket + 1);
        }
    }
}

