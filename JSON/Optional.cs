using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Optional : IPattern
    {
        //Clasa Optional primește un singur pattern și consumă pattern-ul din stringul dat

        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            return match.Success()
                ? match
                : new Match(true, text);
        }
    }
}

