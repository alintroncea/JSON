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
        [InlineData("aaaabc", "bc")]
        [InlineData("aabc", "bc")]
        [InlineData("bc", "bc")]
        [InlineData("abacdfghadl", "bacdfghadl")]
        [InlineData("acdfghadal", "cdfghadal")]
        [InlineData(" ", " ")]
        [InlineData(null, null)]


        public void ReturnsTrueWhenCharInputIsCorrect(string pattern, string remainingText)
        {

            Assert.True(a.Match(pattern).Success());
            Assert.Equal(remainingText, a.Match(pattern).RemainingText());
        }

        Many digits = new Many(new Range('0', '9'));

        [Theory]
        [InlineData("12345ab123", "ab123")]
        [InlineData("ab", "ab")]

        public void ReturnsTrueWhenDigitsInputIsCorrect(string pattern, string remainingText)
        {

            Assert.True(digits.Match(pattern).Success());
            Assert.Equal(remainingText, digits.Match(pattern).RemainingText());
        }

        [Fact]
        public void ReturnFalseWhenTest1InCorrect()
        {
            Many sequence = new Many(
                new Sequence(
                    new Character('a'),
                    new Character('b'),
                    new Character('c')
               )
           );

            var result = (SpecialError)sequence.Match("abcabcabx");
            // 
            // RT = ABX
            Assert.Equal(8, result.Position());
            Assert.Equal("abx", result.RemainingText());
        }
    }
}
