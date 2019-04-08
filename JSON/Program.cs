using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                digit,
            new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
                )
            );

            Console.WriteLine(digit.Match("012").Success());
            Console.WriteLine(digit.Match("12").Success());
            Console.WriteLine(digit.Match("92").Success());
            Console.WriteLine(digit.Match("a9").Success());
            Console.WriteLine(digit.Match(" ").Success());
            Console.WriteLine(digit.Match(null).Success());



            Console.Read();
        }
    }
}
