using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence (params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string original = text;
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);
                if (!match.Success())
                {
                    return new Match(false, original);
                    
                }
                text = match.RemainingText();
                
            }
            return new Match(true, text);
        }
    }
}
