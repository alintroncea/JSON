using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Text : IPattern
    {
        //Clasa Text validează dacă textul este prefixat cu un string dat.


        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text) =>
            !String.IsNullOrEmpty(text) && text.StartsWith(prefix)
                ? new Match(true, text.Substring(prefix.Length))
                : new Match(false, text);
    }
}
