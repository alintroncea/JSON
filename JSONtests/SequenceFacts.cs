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
        [InlineData("abcd", "cd")]
       
        public void ReturnsFalseWhenABiscorrect(string pattern, string remainingText)
        {
            Assert.True(ab.Match(pattern).Success());
            Assert.Equal(remainingText, ab.Match(pattern).RemainingText());

        }

        [Theory]
        [InlineData("def", "def")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void ReturnsFalseWhenABisIncorrect(string pattern, string remainingText)
        {
            Assert.False (ab.Match(pattern).Success());
            Assert.Equal(remainingText, ab.Match(pattern).RemainingText());

        }

        [Theory]
        [InlineData("abcd", "d")]

        public void ReturnsFalseWhenABCiscorrect(string pattern, string remainingText)
        {
            Assert.True(abc.Match(pattern).Success());
            Assert.Equal(remainingText, abc.Match(pattern).RemainingText());

        }


       static Choice hex = new Choice(
    new Range('0', '9'),
    new Range('a', 'f'),
    new Range('A', 'F')
    );

       static Sequence hexSeq = new Sequence(
    new Character('u'),
    new Sequence(
        hex,
        hex,
        hex,
        hex));

        [Theory]
        [InlineData("u1234", "")]
        [InlineData("uabcdef", "ef")]
        [InlineData("uB005 ab", " ab")]

        public void ReturnsFalseWhenHexSeqIscorrect(string pattern, string remainingText)
        {
            Assert.True(hexSeq.Match(pattern).Success());
            Assert.Equal(remainingText, hexSeq.Match(pattern).RemainingText());

        }

        [Theory]
        [InlineData("abc", "abc")]
        [InlineData(null, null)]
       

        public void ReturnsFalseWhenHexSeqIsIncorrect(string pattern, string remainingText)
        {
            Assert.False(hexSeq.Match(pattern).Success());
            Assert.Equal(remainingText, hexSeq.Match(pattern).RemainingText());

        }
    }

}

