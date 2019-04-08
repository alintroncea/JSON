using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Choice : IPattern
    {
      
        readonly IPattern[] patterns;
        Match matchClass = new Match();

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach(var pattern in patterns)
            {
               int the 
                        
            }
            return matchClass;
        }



        //public bool Match(string text)
        //{
        //     foreach(var pattern in patterns)
        //    {

        //        if (pattern.Match(text))
        //            return true;
        //    }

        //    return false;
        //}
    }
}
