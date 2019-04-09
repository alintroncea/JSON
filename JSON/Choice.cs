using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Choice : IPattern
    {
      
        readonly IPattern[] patterns;
       
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach(var pattern in patterns)
            {
                
                if (pattern.Match(text).Success())

                return new Match(true, pattern.Match(text).RemainingText());            
            }
            return new Match(false, text);
        }


    }
}
