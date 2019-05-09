using System;
using Xunit;

namespace JSON
{
    public class RangeFacts
    {
        [Theory]
        [InlineData('1', 'd', "test")]
        [InlineData('a', 'd', " ")]
        [InlineData('a', '3', " test")]
        [InlineData('a', 'f', "1ab")]
        [InlineData('d', 'c', "ad")]

        public void ReturnsFalseWhenInputIsWrong(char start, char end, string match)
        {
            Range range = new Range(start, end);

            var result = (Error)range.Match(match);
            Assert.Equal(0, result.Position());
            Assert.False(result.Success());
        }

        [Theory]
        [InlineData('a', 'b', "abc")]
        [InlineData('a', 'f', "fab")]
        [InlineData('a', 'f', "bcd1")]
        [InlineData('a', 'c', "a")]

        public void ReturnsTrueWhenInputIsCorrect(char start, char end, string match)
        {
            Range range = new Range(start, end);

            var result = range.Match(match);

            Assert.True(result.Success());
        }
    }
}
