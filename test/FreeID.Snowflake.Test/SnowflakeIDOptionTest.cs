using System;
using Xunit;

namespace FreeID.Snowflake.Test
{
    public class SnowflakeIDOptionTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(65)]
        public void InitLength_Error(byte legnth)
        {
            ArgumentException? ex = Assert.Throws<ArgumentException>(() =>
            {
                new SnowflakeIDOption(0, 0, 0, 0, length_Reserve: legnth, 0, 0, 0);
            });

            Assert.NotNull(ex);
        }

        [Theory]
        [InlineData(1, 0, 0, 0)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(0, 0, 1, 0)]
        [InlineData(0, 0, 0, 1)]
        public void InitOrderError(byte order1, byte order2, byte order3, byte order4)
        {
            ArgumentException? ex = Assert.Throws<ArgumentException>(() =>
            {
                _ = new SnowflakeIDOption(
                    order1,
                    order2,
                    order3,
                    order4,
                    SnowflakeIDConst.Length_Reserve,
                    SnowflakeIDConst.Length_TimeStamp,
                    SnowflakeIDConst.Length_WorkingMachineID,
                    SnowflakeIDConst.Length_SerialNumber);
            });

            Assert.NotNull(ex);
        }

        [Fact]
        public void InitLength_Success()
        {
            _ = new SnowflakeIDOption(
                SnowflakeIDConst.Order_Reserve,
                SnowflakeIDConst.Order_TimeStamp,
                SnowflakeIDConst.Order_WorkingMachineID,
                SnowflakeIDConst.Order_SerialNumber,
                SnowflakeIDConst.Length_Reserve,
                SnowflakeIDConst.Length_TimeStamp,
                SnowflakeIDConst.Length_WorkingMachineID,
                SnowflakeIDConst.Length_SerialNumber);
        }
    }
}