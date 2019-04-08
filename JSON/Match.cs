using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Match : IMatch
    {
       private bool successMatch;

        public Match(bool successMatch)
        {
            this.successMatch = successMatch;
        }

        public string RemainingText()
        {
            return "";
        }

        public bool Success()
        {
            return successMatch;
        }
    }
}
