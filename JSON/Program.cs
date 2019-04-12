using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Many(new Character('a'));

            Console.WriteLine(a.Match("aabc").Success());
            Console.WriteLine(a.Match("aabc").RemainingText());
            Console.Read();
        }
    }
}