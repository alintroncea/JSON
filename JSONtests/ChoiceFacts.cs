using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
   public class ChoiceFacts
    {

        static Choice digit = new Choice(new Character('0'),new Range('1', '9'));

        static Choice hex = new Choice(digit,new Choice(new Range('a', 'f'),new Range('A', 'F')));

        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]
        [InlineData("8")]

        public void ReturnTrueWhenTheDigitsFirstCharIsCorrect(string match)
        {
            Assert.True(digit.Match(match).Success());
          
        }

        [Theory]
        [InlineData("a9")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("b")]

        public void ReturnFalseWhenTheDigitsFirstCharIsIncorrect(string match)
        {
            Assert.False(digit.Match(match).Success());

        }


        [Theory]
        [InlineData("012")]
        [InlineData("12")]
        [InlineData("92")]
        [InlineData("a9")]
        [InlineData("f8")]
        [InlineData("A9")]
        [InlineData("F8")]
        

        public void ReturnTrueWhenTheHexFirstCharIsCorrect(string match)
        {
            Assert.True(hex.Match(match).Success());

        }

        [Theory]
       
        [InlineData("G8")]
        [InlineData("g8")]
        [InlineData(null)]
        [InlineData(" ")]


        public void ReturnFalseWhenTheHexFirstCharIsIncorrect(string match)
        {
            Assert.False(hex.Match(match).Success());

        }
    }
}
