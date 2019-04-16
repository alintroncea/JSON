using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class OneOrMore : IPattern
    {
        readonly IPattern pattern;
        readonly IPattern many;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
            many = new Many(pattern);
        }

        public IMatch Match(string text)
        {
            IMatch match = pattern.Match(text);

            if (!match.Success())
                return new Match(false, text);

            return many.Match(match.RemainingText());
        }

    }
}
