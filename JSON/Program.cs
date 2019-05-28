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
              
                Value value = new Value();
                foreach (Object obj in args)
                {
                    var text = File.ReadAllText(@obj.ToString());

                    if (String.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("null");
                    }
                    if (!String.IsNullOrEmpty(text))
                    {
                        text = text.Replace('\r', '\n');
                        File.WriteAllText(@obj.ToString(), text);
                        IMatch match = value.Match(text);

                        if (match.Success())
                            Console.WriteLine("Valid JSON");


                        if (match.Success() && match.RemainingText() != String.Empty)
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
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
            }
        }

        static void DisplayError(int positionError, string inputText)
        {
            int lineCount = 1;
            int columnCounter = 1;
            for (int i = 0; i < inputText.Length; i++)
            {              
                columnCounter++;              
                if (inputText[i] == '\n')
                {
                    columnCounter = 0;
                    lineCount++;
                }
                if (inputText[i] == ' ')
                    columnCounter++;
                if (i == positionError)
                {
                    Console.WriteLine("Error on line :" + lineCount + " at position :" + columnCounter);
                }
            }
        }

    }
}