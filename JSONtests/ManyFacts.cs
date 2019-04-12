using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace JSON
{
   public class ManyFacts
    {
        Many a = new Many(new Character('a'));

        [Theory]
        [InlineData("abc", "bc")]
        


        public void ReturnsTrueWhenInputIsCorrect(string pattern, string remainingText)
        {
           
            Assert.True(a.Match(pattern).Success());
            Assert.Equal(remainingText, a.Match(pattern).RemainingText());
        }
    }
}
