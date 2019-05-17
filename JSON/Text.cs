using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Text : IPattern
    {
        //Clasa Text validează dacă textul este prefixat cu un string dat.
        readonly string prefix;
        readonly IPattern pattern;

        public Text(string prefix)
        {
            this.prefix = prefix;
            IPattern[] patterns = new IPattern[0];
            if (!String.IsNullOrEmpty(prefix))
            {
                foreach (char x in prefix)
                {
                    Array.Resize(ref patterns, patterns.Length + 1);
                    patterns[patterns.Length - 1] = new Character(x);
                }
            }

            pattern = new Sequence(patterns);
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
