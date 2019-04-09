using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
   public class SequenceFacts
    {
        static Sequence ab = new Sequence( new Character('a'),new Character('b'));
        static Sequence abc = new Sequence(ab,new Character('c'));
        static Choice hex = new Choice(new Range('0', '9'),new Range('a', 'f'),new Range('A', 'F'));
        static Sequence hexSeq = new Sequence(new Character('u'), new Sequence( hex, hex,hex, hex));


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

        [Fact]
        public void ReturnsTheCorrectRemainingTextFromHexSeq()
        {
            Assert.Equal("ef", hexSeq.Match("uabcdef").RemainingText());

        }
    }


}
