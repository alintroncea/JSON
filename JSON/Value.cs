using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
                    new StringClass(),
                    new Number(),
                    new Text("true"),
                    new Text("false"),
                    new Text("null")
                );

            var whitespaces = new Many(new Any(" \r\n\t"));
            var element = new Sequence(whitespaces, value, whitespaces);
            var elements = new List(element, new Character(','));

            var array = new Sequence(whitespaces,
               new Character('['),
                elements,
                whitespaces,
                new Character(']'),
                whitespaces
               );

            value.Add(array);

            var member = new Sequence(whitespaces,
                new StringClass(),
                whitespaces,
                new Character(':'), element);

            var members = new List(member, new Character(','));

            var myObject = new Sequence(whitespaces,
                new Character('{'),
                members,
                whitespaces,
                new Character('}'),
                whitespaces
               );

            value.Add(myObject);

            pattern = value;

        }

        public IMatch Match(string text)
        {
            IMatch match = pattern.Match(text);
            return match;

        }
    }
}
