using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Range : IPattern
    {
        private readonly char startChar;
        private readonly char endChar;
        Match matchClass = new Match();

        public Range(char start, char end)
        {
            
            startChar = start;
            endChar = end;
        }

        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
                matchClass.SetSuccess(false);
            else
            {
                char firstCharacter = text[0];
                matchClass.SetSuccess(firstCharacter >= startChar && firstCharacter <= endChar);
            }
            
            return matchClass;
        }

        //public bool Match(string text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //        return false;
        //    char firstCharacter = text[0];
        //    return firstCharacter >= startChar && firstCharacter <= endChar;
        //}
    }
}
