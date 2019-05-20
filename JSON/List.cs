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
          
            if (!match.Success())
            {
               
                if(match is Error error&&!String.IsNullOrEmpty(text))
                return new Match(true, text.Substring(error.Position()));
            }
            return many.Match(match.RemainingText());
        }
    }
}
