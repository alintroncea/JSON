using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Text : IPattern
    {
        //Clasa Text validează dacă textul este prefixat cu un string dat.
      
        readonly IPattern pattern;

        public Text(string prefix)
        {     
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
            IMatch match = pattern.Match(text);
            return match;
        }
    }
}
