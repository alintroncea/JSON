using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Range : IPattern
    {
        private readonly char startChar;
        private readonly char endChar;
       

        public Range(char start, char end)
        {
            
            startChar = start;
            endChar = end;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || text[0] < startChar || text[0] > endChar
                ? new Match(false, text)
                : new Match(true, text.Substring(1));
        }

    }
}
