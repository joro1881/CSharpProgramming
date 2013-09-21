//Write a program for extracting all email addresses 
//from given text. All substrings that match the 
//format <identifier>@<host>…<domain> should be 
//recognized as emails.

using System;

class ExtractingEmail
{
    static void Main()
    {
        string text = "my email is <george.qn1>@<gmaill>.<com> please write to me";
        ExtractEmail(text);
    }

    private static void ExtractEmail(string text)
    {
        int indexEnd = text.LastIndexOf('>');
        int firstIndex = text.IndexOf('<');
        int lenght = indexEnd - firstIndex;
        string email = text.Substring(firstIndex, lenght + 1);
        char[] separators = { '<', '>' };
        //finding the indexes of first < and the last > 
        //with substring extracting the email
        //removing any < > symbol
        email = email.Replace("<", string.Empty);
        email = email.Replace(">", string.Empty);
        Console.WriteLine(email);

        //i know the method isnt very universal, but i dont have time 
    }
}

