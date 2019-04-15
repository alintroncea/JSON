using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new OneOrMore(new Range('0','9'));

            Console.WriteLine(a.Match("bc").Success());
            Console.WriteLine(a.Match("bc").RemainingText());
            Console.Read();
        }
    }
}