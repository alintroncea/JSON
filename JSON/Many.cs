using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Many : IPattern
    {
        readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = pattern.Match(text);
            for (int i = 0; i < 2; i++)
            {
                if (match.Success())
                {
                    match = new Match(true, text.Substring(1));
                    return match;
                }
               
            }
            
           return match;
        }
    }
}
