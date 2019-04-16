using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class ListFacts
    {
        List a = new List(new OneOrMore(new Range('0', '9')), new Character(','));

        [Theory]
        [InlineData("10111,1,2,3", "")]
        [InlineData("1,2,3,", ",")]
        [InlineData("1a", "a")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void ReturnsTrueWhenElementIsRangeAndSeparatorIsChar(string pattern, string remainingText)
        {
            Assert.True(a.Match(pattern).Success());
            Assert.Equal(remainingText, a.Match(pattern).RemainingText());
        }

    }
}
