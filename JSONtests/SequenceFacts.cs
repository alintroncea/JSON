using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSON
{
    public class SequenceFacts
    {

        static Sequence ab = new Sequence(new Character('a'), new Character('b'));
        static Sequence abcde = new Sequence(ab, new Character('c'), new Character('d'), new Character('e'), new Character('e'));

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
            Assert.False(ab.Match(pattern).Success());
            Assert.Equal(remainingText, ab.Match(pattern).RemainingText());

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

        [Theory]
        [InlineData("abcdfff", "abcdfff")]

        public void ReturnsFalseWhenABCisInCorrect(string pattern, string remainingText)
        {
            var error = (Error)abcde.Match(pattern);
            Assert.False(abcde.Match(pattern).Success());
            Assert.Equal(4, error.Position());
            Assert.Equal(remainingText, abcde.Match(pattern).RemainingText());

        }



        [Theory]
        [InlineData("abcx", "abcx")]
        public void ReturnsFalseWhenTest1isInCorrect(string pattern, string remainingText)
        {
            var abcd = new Sequence(
                new Text("abc"),
                new Character('d')
            );
            var error = (Error)abcd.Match(pattern);
            Assert.Equal(3, error.Position());
            Assert.Equal(remainingText, error.RemainingText());
        }

        [Fact]
        public void ReturnFalseWhenTest2IsIncorrect()
        {
            var abcd = new Sequence(
    new Text("abc"),
    new Text("abc"),
    new Text("abc"),
    new Character('d')
);
            var error = (Error)abcd.Match("abcabcabcx");
            Assert.Equal(9, error.Position());

        }

        [Fact]
        public void ReturnFalseWhenTest3IsIncorrect()
        {
            var abcd = new Sequence(
                new Sequence(
                    new Character('a'),
                    new Character('b'),
                        //new Sequence(
                        new Character('c'),
                        new Character('d')
                 //)
                 )
               );

            var error = (Error)abcd.Match("abcx");
            Assert.Equal(3, error.Position());

        }

        [Fact]
        public void ReturnFalseWhenTest4IsIncorrect()
        {
            var abcdef = new Sequence(
                new Sequence(
                    new Character('a'),
                    new Character('b'),
                    new Character('c'),
                    new Character('d'),
                        new Text("efg")
                 )
               );

            var error = (Error)abcdef.Match("abcdefx");
            Assert.Equal(6, error.Position());

        }

        [Fact]
        public void ReturnFalseWhenTest5IsIncorrect()
        {
            var a = new Sequence(
                new Sequence(
                    new Character('a'))
               );

            var error = (Error)a.Match("e");
            Assert.Equal(0, error.Position());

        }

        [Fact]
        public void ReturnFalseWhenTest6IsIncorrect()
        {
            var ab = new Sequence(
                new Sequence(
                    new Character('a'),
                    new Character('b')
                    )
               );

            var error = (Error)ab.Match("ae");
            Assert.Equal(1, error.Position());

        }

        [Fact]
        public void ReturnFalseWhenTest7IsIncorrect()
        {
            var value = new Choice(
                   new StringClass(),
                   new Number(),
                   new Text("true"),
                   new Text("false"),
                   new Text("null")
               );

            var whitespaces = new Many(new Any(" \r\n\t"));
            var element = new Sequence(whitespaces, value, whitespaces);
            var elements = new List(element, new Character(','));

            var array = new Sequence(whitespaces,
                new Character('['),
                whitespaces,
                elements,
                whitespaces,
                new Character(']'),
                whitespaces
               );

          
            var newObject = new Sequence(whitespaces, new Character('['),elements,new Character(']'), whitespaces);
            //var match = members.Match(" \"id\" \"file\" " );
            //var match = myObject.Match(" { \" name\" \"John\" } " );
            //var match = myObject.Match(" { \"menu\" : { \"id\" \"file\" } }");
            var match = newObject.Match("        [\"S\\ufefhi]");
            //var match = myObject.Match(" { \" name\" \"John\" }");
            var error = (Error)match;
            Assert.Equal(16, error.Position());

        }
    }

}

