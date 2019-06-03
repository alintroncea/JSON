using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class AnyFacts
    {
        [Theory]
        [InlineData("eE", "Ea","a")]
        [InlineData("eE", "ea","a")]
        [InlineData("cb", "cdafgh","dafgh")]
        [InlineData("-+", "+3", "3")]
        [InlineData("-+", "-2", "2")]


        public void ReturnsTrueWhenInputIsCorrect(string pattern, string match, string remainingText)
        {
            Any anyClass = new Any(pattern);

            var result = anyClass.Match(match);
            Assert.True(result.Success());
            Assert.Equal(remainingText, result.RemainingText());
        }

        [Theory]
        [InlineData("eE", "a", "a")]
        [InlineData("eE", " ", " ")]
        [InlineData("eE", null, null)]
        [InlineData("-+", "2", "2")]
        [InlineData("-+", " ", " ")]
        [InlineData("-+", null,null)]
        [InlineData(null, " ", " ")]


        public void ReturnsFlaseWhenInputIsInCorrect(string pattern, string match, string remainingText)
        {
            Any anyClass = new Any(pattern);

            var result = anyClass.Match(match);
            Assert.False(result.Success());
            Assert.Equal(remainingText, result.RemainingText());
        }

        [Fact]
        public void ReturnsFlaseWhenInputIsInCorrect2()
        {
            var any = new Any(" \r\n\t");

            var result = any.Match("\r");
            Assert.True(result.Success());
       
        }

    }
}
