using System;
using System.Linq;
using Xunit;

namespace FreeID.Abstraction.Test.Helper
{
    public class TypeConvertDelegateTest
    {
        #region 基础转换

        public class ToLong
        {
            [Theory]
            [InlineData("0", 0L)]
            [InlineData("1", 1L)]
            [InlineData("-1", -1L)]
            public void StringToLong_NoError(string source, long target)
            {
                long result = TypeConvertDelegate2.stringToLong(source);
                Assert.Equal(result, target);
            }

            [Theory]
            [InlineData("0L")]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void StringToLong_Error(string source)
            {
                Exception? ex = Record.Exception(() => TypeConvertDelegate2.stringToLong(source));

                Assert.NotNull(ex);
            }

            [Fact]
            public void BytesToLong_NoError()
            {
                byte[] sourceBytes = new byte[8] { 1, 0, 0, 0, 0, 0, 0, 1 };

                long result = TypeConvertDelegate2.bytesToLong(sourceBytes);
                Assert.Equal(72057594037927937, result);
            }

            [Fact]
            public void BytesToLong_Error()
            {
                byte[] sourceBytes = new byte[1] { 1 };

                Exception? ex = Record.Exception(() => TypeConvertDelegate2.bytesToLong(sourceBytes));

                Assert.NotNull(ex);
            }

            [Fact]
            public void TryBytesToLong_WithOne_NoError()
            {
                byte[] sourceBytes = new byte[1] { 1 };
                long result = TypeConvertDelegate2.tryBytesToLong(sourceBytes);
                Assert.Equal(1L, result);
            }

            [Fact]
            public void TryBytesToLong_WithNull_NoError()
            {
                byte[]? sourceBytes2 = null;
                long result2 = TypeConvertDelegate2.tryBytesToLong(sourceBytes2);
                Assert.Equal(0L, result2);
            }

            [Fact]
            public void TryBytesToLong_WithOverLength_NoError()
            {
                byte[] sourceBytes3 = new byte[9] { 1, 0, 0, 0, 0, 0, 0, 0, 1 };
                long result3 = TypeConvertDelegate2.tryBytesToLong(sourceBytes3);
                Assert.Equal(1L, result3);
            }
        }

        public class ToULong
        {
            [Theory]
            [InlineData("0", 0UL)]
            [InlineData("1", 1UL)]
            [InlineData(null, 0UL)]
            public void StringToULong_NoError(string source, ulong target)
            {
                ulong result = TypeConvertDelegate2.stringToULong(source);
                Assert.Equal(result, target);
            }

            [Theory]
            [InlineData("0L")]
            [InlineData("")]
            [InlineData(" ")]
            public void StringToULong_Error(string source)
            {
                Exception? ex = Record.Exception(() => TypeConvertDelegate2.stringToULong(source));

                Assert.NotNull(ex);
            }

            [Fact]
            public void BytesToULong_NoError()
            {
                byte[] sourceBytes = new byte[8] { 1, 0, 0, 0, 0, 0, 0, 1 };

                ulong result = TypeConvertDelegate2.bytesToULong(sourceBytes);
                Assert.Equal(72057594037927937UL, result);
            }

            [Fact]
            public void BytesToULong_Error()
            {
                byte[] sourceBytes = new byte[1] { 1 };

                Exception? ex = Record.Exception(() => TypeConvertDelegate2.bytesToULong(sourceBytes));

                Assert.NotNull(ex);
            }

            [Fact]
            public void TryBytesToULong_WithOne_NoError()
            {
                byte[] sourceBytes = new byte[1] { 1 };
                ulong result = TypeConvertDelegate2.tryBytesToULong(sourceBytes);
                Assert.Equal(1UL, result);
            }

            [Fact]
            public void TryBytesToULong_WithNull_NoError()
            {
                byte[]? sourceBytes2 = null;
                ulong result2 = TypeConvertDelegate2.tryBytesToULong(sourceBytes2);
                Assert.Equal(0UL, result2);
            }

            [Fact]
            public void TryBytesToULong_WithOverLength_NoError()
            {
                byte[] sourceBytes3 = new byte[9] { 1, 0, 0, 0, 0, 0, 0, 0, 1 };
                ulong result3 = TypeConvertDelegate2.tryBytesToULong(sourceBytes3);
                Assert.Equal(1UL, result3);
            }
        }

        public class ToBytes
        {
            [Fact]
            public void LongToBytes_WithZero_NoError()
            {
                byte[]? result = TypeConvertDelegate2.longToBytes(0L);
                Assert.Equal(8, result.Length);
                Assert.Equal(0, result.Sum(t => t));
            }

            [Fact]
            public void LongToBytes_WithMax_NoError()
            {
                byte[] result = TypeConvertDelegate2.longToBytes(long.MaxValue);
                Assert.Equal(8, result.Length);
                Assert.Equal(1785, result[0..7].Sum(t => t));//前7个255相加
                Assert.Equal(127, result[7]);
            }

            [Fact]
            public void LongToBytes_WithMin_NoError()
            {
                byte[] result = TypeConvertDelegate2.longToBytes(long.MinValue);
                Assert.Equal(8, result.Length);
                Assert.Equal(0, result[0..7].Sum(t => t));
                Assert.Equal(128, result[7]);
            }

            [Fact]
            public void ULongToBytes_WithZero_NoError()
            {
                byte[]? result = TypeConvertDelegate2.ulongToBytes(0UL);
                Assert.Equal(8, result.Length);
                Assert.Equal(0, result.Sum(t => t));
            }

            [Fact]
            public void ULongToBytes_WithMax_NoError()
            {
                byte[] result = TypeConvertDelegate2.ulongToBytes(ulong.MaxValue);
                Assert.Equal(8, result.Length);
                Assert.Equal(1785, result[0..7].Sum(t => t));//前7个255相加
                Assert.Equal(255, result[7]);//ulong不使用补码 所以最后一个是255
            }

            [Fact]
            public void ULongToBytes_WithMin_NoError()
            {
                byte[] result = TypeConvertDelegate2.ulongToBytes(ulong.MinValue);
                Assert.Equal(8, result.Length);
                Assert.Equal(0, result[0..7].Sum(t => t));
                Assert.Equal(0, result[7]);
            }
        }

        public class ToFormatString
        {
            public class ByteToString
            {
                [Theory]
                [InlineData(0b11, "11")]
                [InlineData(0b101, "101")]
                [InlineData(0b1111_1111, "11111111")]
                public void ToBitString_NoError(byte source, string expected)
                {
                    string result = TypeConvertDelegate2.byteToBitString(source);

                    Assert.Equal(expected, result);
                }

                [Theory]
                [InlineData(0b11, "3")]
                [InlineData(0b1010, "12")]
                [InlineData(0b1111_1111, "377")]
                public void ToOctalString_NoError(byte source, string expected)
                {
                    string result = TypeConvertDelegate2.byteToOctalString(source);

                    Assert.Equal(expected, result);
                }

                [Theory]
                [InlineData(0b11, "3")]
                [InlineData(0b1010, "10")]
                [InlineData(0b1111_1111, "255")]
                public void ToDecimalString_NoError(byte source, string expected)
                {
                    string result = TypeConvertDelegate2.byteToDecimalString(source);

                    Assert.Equal(expected, result);
                }

                [Theory]
                [InlineData(0b11, "3")]
                [InlineData(0b1010, "a")]
                [InlineData(0b1111_1111, "ff")]
                public void ToHexString_NoError(byte source, string expected)
                {
                    string result = TypeConvertDelegate2.byteToHexString(source);

                    Assert.Equal(expected, result);
                }
            }
        }

        #endregion 基础转换

        #region 组合转换

        public class BytesToString
        {
        }

        #endregion 组合转换
    }
}