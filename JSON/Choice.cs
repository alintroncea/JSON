using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
   public class Choice : IPattern
    {
      
        readonly IPattern[] patterns;
        Match matchClass;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach(var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                matchClass = new Match(true);
                else
                {
                    matchClass = new Match(false);
                }
            }
            return matchClass;
        }



        //public bool Match(string text)
        //{
        //    foreach(var pattern in patterns)
        //    {

        //        if (pattern.Match(text))
        //            return true;
        //    }

        //    return false;
        //}
    }
}
