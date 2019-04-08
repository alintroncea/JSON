﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{

    public class Character : IPattern
    {
        Match matchClass;
        readonly char pattern;
    
        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                matchClass = new Match(false);
            }
            else
            {
                matchClass = new Match(text[0] == pattern);
            }
            

            return matchClass;
        }



        //public bool Match(string text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //        return false;

        //    return text[0] == pattern;
        //}


    }
}
