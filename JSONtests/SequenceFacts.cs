using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class SequenceFacts
    {
        static Sequence ab = new Sequence(new Character('a'), new Character('b'));
        static Sequence abc = new Sequence(ab, new Character('c'));


        [Theory]
        [InlineData("abc")]
        [InlineData("ab")]


        public void ReturnsTrueWhenASequenceOfCharsIsCorrect(string match)
        {
            Assert.True(ab.Match(match).Success());

        }


        [Theory]
        [InlineData("def")]
        [InlineData(" ")]
        [InlineData(null)]


        public void ReturnsTrueWhenASequenceOfCharsIsInCorrect(string match)
        {
            Assert.False(ab.Match(match).Success());

        }


        [Fact]
        public void ReturnsTheCorrectRemainingTextFromAb()
        {
            Assert.Equal("cd", ab.Match("abcd").RemainingText());

        }

        [Fact]
        public void ReturnsTheCorrectRemainingTextFromAbc()
        {
            Assert.Equal("def", abc.Match("def").RemainingText());

        }

        static Sequence hex = new Sequence(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));

        [Theory]
        [InlineData("2cE", "")]


        public void ReturnsTrueWhenASequenceOfHexIsCorrect(string pattern, string remainingText)
        {
            Assert.True(hex.Match(pattern).Success());
            Assert.Equal(remainingText, hex.Match(pattern).RemainingText());

        }


        static Sequence hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));

        [Theory]
        [InlineData("u1234", "")]
        [InlineData("uabcdef", "ef")]
        [InlineData("uB005 ab", " ab")]

        public void ReturnsTrueWhenASequenceOfHexSeqIsCorrect(string pattern, string remainingText)
        {
            Assert.True(hexSeq.Match(pattern).Success());
            Assert.Equal(remainingText, hexSeq.Match(pattern).RemainingText());

        }

        [Theory]
        [InlineData("abc", "abc")]
        [InlineData(null, null)]


        public void ReturnsFalseWhenASequenceOfHexSeqIsIncorrect(string pattern, string remainingText)
        {
            Assert.False(hexSeq.Match(pattern).Success());
            Assert.Equal(remainingText, hexSeq.Match(pattern).RemainingText());

        }

       
    }


}
