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
            Optional minus = new Optional(new Character('-'));
   
            OneOrMore numbers =new OneOrMore(new Range('0', '9'));
            Optional scientific = new Optional(new Character('e'));

            pattern = new Many(new Sequence(minus,numbers,scientific,numbers));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }

    }
}
