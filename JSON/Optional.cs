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
            if (!String.IsNullOrEmpty(text))
            {
                var match = pattern.Match(text);

                if (match.Success())
                    return match;
            }
            return new Match(true, text);
        }
    }
}

