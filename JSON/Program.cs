using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number();
            IMatch match = number.Match("121e");

            Console.WriteLine("Success :" + match.Success());
            Console.WriteLine("Remaining Text :" + match.RemainingText());
            Console.Read();
        }
    }
}