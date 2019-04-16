using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Optional
    {
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

