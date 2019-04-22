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
            Choice scientific = new Choice(new Character('e'), new Character('E'));
            Choice signs = new Choice(new Character('+'), new Character('-'));

           
            Sequence numbersAndDot = new Sequence(numbers, dot, numbers);
            Choice numbersOrMinus = new Choice(minus, naturalNumber);
            Choice numbersOrDot = new Choice(numbersAndDot,naturalNumber);
            Optional numbersAndScientific = new Optional(new Sequence(scientific,new Optional(signs),numbers));


            pattern = new Sequence(numbersOrMinus,numbersOrDot,numbersAndScientific);
      
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }

    }
}
