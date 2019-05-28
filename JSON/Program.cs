using System;
using System.IO;


namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                char[] whitespaces = { '\t', '\r' };
                Value value = new Value();
                foreach (Object obj in args)
                {
                    var text = File.ReadAllText(@obj.ToString());

                    foreach(char currentChar in text)
                    {
                        for(int i = 0; i < whitespaces.Length; i++)
                        {
                            if(currentChar == whitespaces[i])
                            {
                                text = text.Replace(currentChar, ' ');
                                File.WriteAllText("C:\\Users\\Alin\\Desktop\\NewDocument.txt", text);
                            }
                        }
                    }
 
                    IMatch match = value.Match(text);
                   
                    if (match.Success())
                        Console.WriteLine("Valid JSON" );

                    if (match.Success()&&match.RemainingText()!= String.Empty)
                    {
                        int positionError = text.Length - match.RemainingText().Length;
                        DisplayError(positionError, match.RemainingText());
                    }
                    if (!match.Success())
                    {
                        Error error = (Error)match;
                        DisplayError(error.Position(), text);
                       
                    }
                }
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
            }
        }

        static void DisplayError(int positionError, string inputText)
        {
            int lineCount = 1;
            int columnCounter = 0;
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == ' ')
                    continue;

                columnCounter++;

                if (inputText[i] == '\n')
                {
                    columnCounter = 0;
                    lineCount++;
                }
                if (i == positionError)
                {
                    Console.WriteLine("Error on line :" + lineCount + " at position :" + columnCounter);
                }
            }
        }

    }
}