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
                   
                    IMatch match = value.Match(text);
                    int lineCount = 1;

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == '\n')
                        {
                            lineCount++;
                        }
                    }
                    Console.WriteLine("Success : " + match.Success());
                    Console.WriteLine("Remaining text :" + match.RemainingText());
                    Console.WriteLine("Number of lines :" + lineCount);


                    if (!match.Success())
                    {
                       
                        Error error = (Error)match;
                        Console.WriteLine("Error at position :" + error.Position());
                    }
                }   
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
            }
        }


    }
}