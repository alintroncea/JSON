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

                        if (match.Success())
                            Console.WriteLine("Valid JSON");

                        if (match.Success() && match.RemainingText() != String.Empty)
                        {
                            int positionError = text.Length - match.RemainingText().Length;
                          

                        }
                        if (!match.Success())
                        {
                            Error error = (Error)match;
                         
                        }
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