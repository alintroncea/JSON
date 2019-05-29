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
                    string[] lines = File.ReadAllLines(@obj.ToString());

                    if (!String.IsNullOrEmpty(text))
                    {
                        IMatch match = value.Match(text);

                        if (match.Success())
                            Console.WriteLine("Valid JSON");

                        if (match.Success() && match.RemainingText() != String.Empty)
                        {
                            int positionError = text.Length - match.RemainingText().Length;
                            DisplayError(positionError, lines);
                        }
                        if (!match.Success())
                        {
                            Error error = (Error)match;
                            DisplayError(error.Position(), lines);
                        }
                    }

                }
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
            }
        }

        static void DisplayError(int positionError, string[] lines)
        {
            int elementCounter = 1;
            int lineCounter = 0;
            foreach (string line in lines)
            {
                lineCounter++;
                int charCounter = 1;
                foreach (char c in line)
                {
                    charCounter++;
                    elementCounter++;
                    if (elementCounter == positionError)
                    {
                        Console.WriteLine("Error on line :" + lineCounter + " at position :" + charCounter);
                     
                    }
                }
            }
        }

    }
}