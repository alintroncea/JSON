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
            if (String.IsNullOrEmpty(text))
                return new Match(false, text);
           
            char firstCharacter = text[0];
            return new Match(firstCharacter >= startChar && firstCharacter <= endChar, text.Substring(1));
           
           
        }

    }
}
