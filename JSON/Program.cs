using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {


            //"C:\Users\ecigoya\Desktop\NewDocument.txt";        
            //string text = System.IO.File.ReadAllText(@args[0]);;
            //Value value = new Value();
            //IMatch match = value.Match(text);

            //Console.WriteLine(match.Success());
            //Console.Read();

            // Test if input arguments were supplied:
            if (args.Length > 0)
            {
                Console.WriteLine("Arguments Passed by the Programmer:");

                // To print the command line  
                // arguments using foreach loop 
                foreach (Object obj in args)
                {
                    Console.WriteLine(obj);
                }
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
            }
        }

      
    }
}