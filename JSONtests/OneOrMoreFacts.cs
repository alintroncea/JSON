using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class OneOrMoreFacts
    {
        OneOrMore a = new OneOrMore(new Range('0', '9'));

        [Theory]
        [InlineData("123", "")]
        [InlineData("1a", "a")]


        public void ReturnsTrueWhenCharRangeIsCorrect(string pattern, string remainingText)
        {

            Assert.True(a.Match(pattern).Success());
            Assert.Equal(remainingText, a.Match(pattern).RemainingText());
        }

        [Theory]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void ReturnsFalseWhenRangeInputIsIncorrect(string pattern, string remainingText)
        {

            Assert.False(a.Match(pattern).Success());
            Assert.Equal(remainingText, a.Match(pattern).RemainingText());
        }

        [Fact]

        public void ReturnFalseAtTest1()
        {
            OneOrMore newOneOrMore = new OneOrMore(new Text("abc"));
            IMatch match = newOneOrMore.Match("ab");
            var error = (Error)match;
            Assert.Equal(2,error.Position());
        }
    }
}
