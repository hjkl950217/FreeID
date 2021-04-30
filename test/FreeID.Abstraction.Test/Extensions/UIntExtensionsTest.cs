using System;
using Xunit;

namespace FreeID.Abstraction.Test.Extensions
{
    public class UIntExtensionsTest
    {
        public class ToBinString
        {
            [Theory]
            [InlineData(0b11, "11")]
            [InlineData(0b101, "101")]
            [InlineData(0b1111_1111, "11111111")]
            public void ToBitString_NoError(uint source, string expected)
            {
                string result = source.ToBinString();

                Assert.Equal(expected, result);
            }
        }

        public class ToOctString
        {
            [Theory]
            [InlineData(0b11, "3")]
            [InlineData(0b1010, "12")]
            [InlineData(0b1111_1111, "377")]
            public void ToOct_NoError(uint source, string expected)
            {
                string result = source.ToOctString();

                Assert.Equal(expected, result);
            }
        }

        public class ToDecString
        {
            [Theory]
            [InlineData(0b11, "3")]
            [InlineData(0b1010, "10")]
            [InlineData(0b1111_1111, "255")]
            public void ToDecString_NoError(uint source, string expected)
            {
                string result = source.ToDecString();

                Assert.Equal(expected, result);
            }
        }

        public class ToHexString
        {
            [Theory]
            [InlineData(0b11, "3")]
            [InlineData(0b1010, "a")]
            [InlineData(0b1111_1111, "ff")]
            public void ToHexString_NoError(uint source, string expected)
            {
                string result = source.ToHexString();

                Assert.Equal(expected, result);
            }
        }
    }
}