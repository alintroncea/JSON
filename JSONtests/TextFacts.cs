using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class TextFacts
    {
        [Theory]
        [InlineData("true", "true", "")]
        [InlineData("true", "truedat", "dat")]
        [InlineData("false", "false", "")]
        [InlineData("false", "falseX", "X")]
        [InlineData("", "true", "true")]
        

        public void ReturnsTrueWhenInputIsCorrect(string pattern, string match, string remainingText)
        {
            Text textClass = new Text(pattern);

            var result = textClass.Match(match);
            Assert.True(result.Success());
            Assert.Equal(remainingText, result.RemainingText());
        }

        [Theory]
        [InlineData("true",null)]
        [InlineData("true", "")]
        [InlineData("true", "trux")]
        [InlineData("", null)]
        [InlineData(null, null)]

        public void ReturnsTrueWhenInputIsInCorrect(string pattern, string text)
        {
            Text textClass = new Text(pattern);

            var result = textClass.Match(text);
            Assert.False(result.Success());
            Assert.Equal(text, result.RemainingText());
        }


    }
}
