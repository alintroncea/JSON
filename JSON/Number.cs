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

            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);
            var zero = new Character('0');
            var naturalNumber = new Choice(zero, digits);
            var integer = new Sequence(new Optional(new Character('-')), naturalNumber);
            var fractional = new Sequence(new Character('.'), digits);
            var exponential = new Sequence(new Any("eE"), new Optional(new Any("+-")), digits);


            pattern = new Sequence(integer, new Optional(fractional), new Optional(exponential));


        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }

    }
}
