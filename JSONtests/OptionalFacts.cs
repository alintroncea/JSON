using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace JSON
{
    public class OptionalFacts
    {
        Optional a = new Optional(new Character('a'));


        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aabc", "abc")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]


        public void ReturnsTrueWhenCharInputIsCorrect(string pattern, string remainingText)
        {

            Assert.True(a.Match(pattern).Success());
            Assert.Equal(remainingText, a.Match(pattern).RemainingText());
        }


        Optional sign = new Optional(new Character('a'));

        [Theory]
        [InlineData("-123", "-123")]
        [InlineData("123", "123")]



        public void ReturnsTrueWhenSignInputIsCorrect(string pattern, string remainingText)
        {

            Assert.True(sign.Match(pattern).Success());
            Assert.Equal(remainingText, sign.Match(pattern).RemainingText());
        }

    }
}
