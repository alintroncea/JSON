using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Match : IMatch
    {
    
        readonly bool successMatch;
        readonly string text;

        public Match(bool successMatch, string text)
        {
            this.successMatch = successMatch;
            this.text = text;
          
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return successMatch;
        }

    }
}
