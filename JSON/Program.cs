using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number();
            IMatch match = number.Match("01");

            Console.WriteLine("Success :" + match.Success());
            Console.WriteLine("Remaining Text :" + match.RemainingText());
            Console.Read();
        }
    }
}