using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class OneOrMore : IPattern
    {
        //Clasa OneOrMore primește un singur pattern și consumă pattern-ul din stringul dat când acesta apare măcar odată.

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
            {
                Error error = (Error)match;

                return new Error(error.Position(), text);
            }
               

            return many.Match(match.RemainingText());
        }

    }
}
