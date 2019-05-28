using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class SpecialError : IMatch
    {
        private int position;
        readonly string remainingText;
        public SpecialError(int position, string remainingText)
        {
            this.position = position;
            this.remainingText = remainingText;
        }
        public bool Success()
        {
            return true;
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
