using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class ListError : IMatch
    {
        readonly int position;
        readonly string remainingText;

        public ListError(int position, string remainingText)
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
