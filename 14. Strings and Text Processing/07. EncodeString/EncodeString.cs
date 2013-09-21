//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters. The encoding/decoding is done by 
//performing XOR (exclusive or) operation over the first letter of the string with
//the first of the key, the second – with the second, etc. When the last key character
//is reached, the next is the first.

using System;
using System.Text;

class EncodeString
{
    static void Main()
    {
        string cipher = "encryptionkey";
        //string userString = Console.ReadLine();
        string userString = "I may not be Johnny Bravo, but still I don't have luck with the ladies";
        //two strings for treatment
        Console.WriteLine(cipher);
        Console.WriteLine(userString);
        Console.WriteLine();

        //encoding with XOR method
        string encrypt = Encoding(cipher, userString);
        Console.WriteLine("Encode text :\n{0} ", encrypt);
        Console.WriteLine();
        //after give the encrypted string + the key
        //the method start works in return order
        string decript = Encoding(cipher, encrypt);

        //again the original text
        Console.WriteLine(decript);
    }

    private static string Encoding(string cipher, string userString)
    {
        //we have two char arrays
        //one for containt the original string
        char[] userArr = userString.ToCharArray();
        //second one, empty because we want to 
        //fill it with equal cipher characters 
        char[] cipherArr = new char[userString.Length];

        StringBuilder encrypted = new StringBuilder();

        //logic for fill the cipher array
        for (int i = 0, k = 0; i < cipherArr.Length; k++, i++)
        {
            //when k counted all chars from cipher(string)
            //we reset it
            if (k == cipher.Length)
            {
                k = 0;
            }
            //every element of the cipher array
            // takes the value of the cipher string(array) 
            cipherArr[i] = cipher[k];
        }

        for (int i = 0; i < userArr.Length; i++)
        {
            //XOR logic 
            encrypted.Append((char)(userArr[i] ^ cipherArr[i]));
        }
        //we can see after the operation 
        //the result is number 
        Console.WriteLine(userArr[1] ^ cipherArr[1]);

        //with .ToString we are taking back the number to any char symbol from ASCII
        return encrypted.ToString();
    }
}

