using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Error : IMatch
    {
        readonly int position;
        readonly string remainingText;

        public Error(int position, string remainingText)
        {
            this.position = position;
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return false;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public int Position()
        {
            return position;
        }
    }
}
