using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class OneOrMore : IPattern
    {
        readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }
        public IMatch Match(string text)
        {
            string original = text;
            if (!String.IsNullOrEmpty(text))
            {
                IMatch match;
                bool found = false;
                foreach (char c in text)
                {
                    match = pattern.Match(text);
                    if (match.Success())
                    {
                        found = true;
                        text = match.RemainingText();
                    }
                }
                return !found ? 
                    new Match(false, original):
                    new Match(true, text);
            }
            return new Match(false, original);
        }
    }
}
