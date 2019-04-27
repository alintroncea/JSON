using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Choice : IPattern
    {

        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);
                if (match.Success())
                    return match;
            }
            return new Match(false, text);
        }

        public void Add(IPattern patternToAdd)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = patternToAdd;
        }

    }
}
