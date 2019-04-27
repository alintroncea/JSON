using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class ValueFacts
    {
        static Value value = new Value();

        [Theory]
        [InlineData("12.123E-2", "")]
        [InlineData("12.123E", "E")]
        [InlineData("1E2.123E-2", ".123E-2")]
        [InlineData("12.", ".")]
        [InlineData("\"Te+st\"", "")]
        [InlineData("\"Te st *\"", "")]
        [InlineData("\" \\\\ \"", "")]
        [InlineData("\"\"", "")]
        [InlineData("true", "")]
        [InlineData("false", "")]
        [InlineData("[2]", "")]
        [InlineData("[\t]", "")]
        [InlineData("[\n]", "")]
        [InlineData("[\r]", "")]
        [InlineData("[ ]", "")]
        [InlineData("[\r24]", "")]
        [InlineData("[324]", "")]
        [InlineData("[1,2]", "")]
        [InlineData(" [ 1,2 ] ", "")]
        [InlineData("\"d\"", "")]
        [InlineData("\"da\"", "")]
        [InlineData("[true,false]", "")]
        [InlineData("{\"name\":\"John\",\"age\":30,\"car\":null}", "")]
        [InlineData("{\"boolean\":\"true\"}", "")]
        [InlineData("{}", "")]



        public void ReturnTrue(string pattern, string remainingText)
        {
            IMatch match = value.Match(pattern);
            Assert.Equal(remainingText, match.RemainingText());
            Assert.True(match.Success());
        }

      
    }
}
