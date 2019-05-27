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
            int counter = 0;
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);
             
                if (match.Success())
                {
                    return match;
                }


                if (match is Error error && error.Position() > counter)
                {
                    counter = error.Position();
                }

            }
            return new Error(counter, text);
        }

        public void Add(IPattern patternToAdd)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = patternToAdd;
        }

    }
}
