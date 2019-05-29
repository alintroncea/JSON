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

                    if (!String.IsNullOrEmpty(text))
                    {
                        IMatch match = value.Match(text);
                        text = text.Replace("\r", "\n");
                        File.WriteAllText(@obj.ToString(), text);
                        string[] lines = File.ReadAllLines((@obj.ToString()));

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
                            DisplayError(error.Position(),lines);
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
            int lineCount = 0;
            int counter = 0;

            foreach (string line in lines)
            {
                lineCount++;
                int elementCount = 0;
                foreach (char c in line)
                {
                    elementCount++;
                    counter++;
                    if (counter == positionError)
                    {
                        Console.WriteLine("Error at line " + lineCount + " on position " + elementCount);

                    }

                }
            }
            //for (int i = 0; i < input.Length; i++)
            //{
            //    elementCount++;
            //    Console.WriteLine(i + " :" + input[i]);
            //    if (input[i] == '\n')
            //    {
            //        lineCount++;
            //    }                   

            //    if (i == positionError)
            //    {

            //    }
            //}



        }

    }
}