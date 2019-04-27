using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class StringClass : IPattern
    {
        private readonly IPattern pattern;

        public StringClass()
        {
            var singleChar = new Choice(
                new Range((char)31, (char)33),
                new Range((char)35, (char)91),
                new Range((char)93, (char)ushort.MaxValue)
            );
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );
            var hexSeq = new Sequence(
                new Character('u'),
                hex, hex, hex, hex
            );
            var escapeChars = new Choice(new Any("\"\\/bnrt"), hexSeq);
            var escapeSeq = new Sequence(new Character('\\'), escapeChars);
            var character = new Choice(
                singleChar,
                escapeSeq      
            );
            var characters = new Many(character);

            pattern = new Sequence(new Character('"'), 
                characters,
                new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
