using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{

    public class Character : IPattern
    {
        //primul caracter din text se potriveste cu pattern-ul?

        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text) 
            => String.IsNullOrEmpty(text) || text[0] != pattern
                ? (IMatch) new Error(0, text)
                : new Match(true, text.Substring(1));
    }
}