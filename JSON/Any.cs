using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
            => !String.IsNullOrEmpty(text) && accepted?.Contains(text[0]) == true
                ? new Match(true, text.Substring(1))
                : (IMatch)new Error(0, text);
    }
}
