using System;
using Xunit;
namespace JSON
{
   public class CharacterFacts
    {
        [Theory]
        [InlineData('1', "test")]
        [InlineData('a', " ")]
        [InlineData('a', " test")]
        [InlineData('a', "1ab")]
        [InlineData('d', "ad")]

        public void ReturnsFalseWhenInputIsWrong(char pattern, string match)
        {
            Character character = new Character(pattern);

            var result = (Error)character.Match(match);
            Assert.Equal(0, result.Position());
            Assert.False(result.Success());
        }

        [Theory]
        [InlineData('a', "abc")]
        [InlineData('f',  "fab")]
        [InlineData('b', "bcd1")]
        [InlineData('1', "1a")]

        public void ReturnsTrueWhenInputIsCorrect(char pattern, string match)
        {
            Character character = new Character(pattern);

            var result = character.Match(match);
            Assert.True(result.Success());
        }
    }
}
