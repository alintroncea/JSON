using System;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            List a = new List(new Range('0', '9'), new Character(','));
            Console.WriteLine(a.Match("abc").Success());
            Console.Read();
        }
    }
}