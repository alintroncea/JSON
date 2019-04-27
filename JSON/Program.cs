using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            StringClass stringClass = new StringClass();
            IMatch match = stringClass.Match("\"Te\\\"st\"");

            Console.WriteLine(match.RemainingText());
            Console.Read();
        }
    }
}