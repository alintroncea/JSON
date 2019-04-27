﻿using System;
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

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
