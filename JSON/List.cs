using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class List : IPattern
    {
        readonly IPattern element;
        readonly IPattern separator;

        readonly Many many;

        public List(IPattern element, IPattern separator)
        {
            this.element = element;
            this.separator = separator;
            many = new Many(new Sequence(separator, element));
        }

        public IMatch Match(string text)
        {
            IMatch match = element.Match(text);
       
            if (match.Success())
            {
                int positionError = text == null
                    ? 0
                    : text.Length - match.RemainingText().Length;

                match = many.Match(match.RemainingText());
                SpecialError specialError = (SpecialError)match;

                return new SpecialError(positionError + specialError.Position(), specialError.RemainingText());
             
            }
            if (match is Error error)
            {
                return new SpecialError(error.Position(), text);
            }
            return match;
        }
    }
}
