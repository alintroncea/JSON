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
                    var lineCount = File.ReadAllLines(@obj.ToString());
                    IMatch match = value.Match(text);

                    Console.WriteLine("Success : " + match.Success());
                    Console.WriteLine("Remaining text :" + match.RemainingText());
                  
                }
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
            }
        }


    }
}