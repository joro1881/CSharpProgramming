//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//        The expected result:
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
using System;
using System.IO;

class ChangePartOfTextToUpper
{
    static void Main()
    {
        try
        {
            string txtFile = @"..\..\text.txt";
            TextToUpper(txtFile);
        }
        catch (FileNotFoundException FNFE)
        {
            Console.WriteLine(FNFE.Message);
        }
        catch (FileLoadException FLE)
        {
            Console.WriteLine(FLE.Message);
        }
        catch (IOException IOE)
        {
            Console.WriteLine(IOE.Message);
        }
    }

    private static void TextToUpper(string txtFile)
    {
        StreamReader reader = new StreamReader(txtFile);
        using (reader)
        {
            int startSeq = 0;
            int endSeq = 0;
            int length = 0;
            string line = reader.ReadLine();
            Console.WriteLine(line);
 
            for (int i = 0; i < line.Length - 8; i++)
            {
                //we are using one cycle to walk every substring
                // in searchin of th tags
                if (line.Substring(i, 8) == "<upcase>")
                {
                    //when we find them, write the position to container parameter           
                    startSeq = i + 8;
                    i = startSeq;
                }
                if (line.Substring(i, 9) == "</upcase>")
                {
                    endSeq = i;

                    length = endSeq - startSeq;
                    //finding the lenght betwen first and last position
                    string upperLetters = line.Substring(startSeq, length).ToUpper();
                    //getting the substring, making it to Upper
                    line = line.Remove(startSeq, length);
                    //removing the not nessecary, inserting the new string
                    line = line.Insert(startSeq, upperLetters);
                    line = line.Remove(startSeq - 8, 8);
                    line = line.Remove(endSeq - 8, 9);
                }
            }
            Console.WriteLine();
            Console.WriteLine(line);
            line = reader.ReadLine();
        }
    }
}

