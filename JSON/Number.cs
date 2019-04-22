using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {

            Range number = new Range('0', '9');
            OneOrMore numbers = new OneOrMore(number);
            Character zero = new Character('0');
            Optional dot = new Optional(new Character('.'));
            Choice naturalNumber = new Choice(zero, numbers);
            Optional minus = new Optional(new Character('-'));
            Optional scientific = new Optional(new Choice(new Character('e'), new Character('E')));
            Optional signs = new Optional(new Choice(new Character('+'), new Character('-')));

           
            Sequence numbersAndDot = new Sequence(numbers, dot, numbers);
            Choice numbersAndScientific = new Choice(new Sequence(scientific,signs,naturalNumber));

            pattern = new Sequence(new Choice(minus,naturalNumber),new Choice(numbersAndDot,naturalNumber),
               new Optional(numbersAndScientific));
           



        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }

    }
}
