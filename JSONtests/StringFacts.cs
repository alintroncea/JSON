using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
   public class StringFacts
    {

        StringClass stringClass = new StringClass();

        [Theory]
        [InlineData("\"a\"", "")]
        [InlineData("\"ag\"", "")]
        [InlineData("\"Test\"", "")]
        [InlineData("\"a0\"", "")]
        [InlineData("\"34\"", "")]
        [InlineData("\"Te st\"", "")]
        [InlineData("\"Te+st\"", "")]
        [InlineData("\"Te st *\"", "")]
        [InlineData("\" \\\\ \"", "")]
        [InlineData("\"\"", "")]
        [InlineData("\"Te\\\"st\"", "")]
        [InlineData("\"Te\"st\"", "st\"")]
        [InlineData("\"\\nAnother line\"", "")]
        [InlineData("\"Test\\u0097\\nAnother line\"", "")]


        public void ReturnTrue(string pattern, string remainingText)

        {
            IMatch match = stringClass.Match(pattern);
            Assert.Equal(remainingText, match.RemainingText());
            Assert.True(match.Success());
        }

        [Theory]
        [InlineData("\" \\ \"")]

        public void ReturnFalse(string pattern)

        {
            IMatch match = stringClass.Match(pattern);
            Assert.Equal(pattern, match.RemainingText());
            Assert.False(match.Success());
        }

    }
}
