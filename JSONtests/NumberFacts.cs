using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
   public class NumberFacts
    {

        static Number number = new Number();

        [Theory]
        [InlineData("12.", ".")]
        [InlineData("12.23", "")]
        [InlineData("256", "")]
        [InlineData("12.123e3", "")]
        [InlineData("12.123E3", "")]
        [InlineData("12.123E+3", "")]
        [InlineData("12.123E-2", "")]
        [InlineData("12.123E", "E")]


        //[InlineData("01", "1")]


        public void ReturnTrue(string pattern, string remainingText)

        {
            IMatch match = number.Match(pattern);
            Assert.Equal(remainingText, match.RemainingText());
            Assert.True( match.Success());
        }


        [Theory]
        [InlineData("e", "e")]
       
       

        public void ReturnFalse(string pattern, string remainingText)

        {
            IMatch match = number.Match(pattern);
            Assert.False(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }
    }
}
