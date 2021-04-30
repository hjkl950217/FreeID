using System.Collections.Generic;
using Xunit;

namespace FreeID.Snowflake.Test
{
    public class SnowflakeIDTest
    {
        public class GetIDOrDefault
        {
            [Fact]
            public void ReturnZero_WithNullObjectReference()
            {
                SnowflakeID? snowflakeID = null;
                ulong result = snowflakeID.GetIDOrDefault();
                Assert.Equal(0UL, result);
            }

            [Fact]
            public void ReturnZero_WithNullSnowflakeID()
            {
                SnowflakeID? snowflakeID = SnowflakeID.Null;
                ulong result = snowflakeID.GetIDOrDefault();
                Assert.Equal(0UL, result);
            }
        }

        public class EqualsTest
        {
            public class NullReferenceTestData
            {
                public static IEnumerable<object[]> Data
                {
                    get
                    {
                        return new List<object[]>
                        {
#pragma warning disable CS8625 // 无法将 null 文本转换为不可为 null 的引用类型。
                            new object[] { SnowflakeID.Null, SnowflakeID.Null},
                            new object[] { SnowflakeID.Null, null },
                            new object[] { null, SnowflakeID.Null },
                            new object[] { null,null },
#pragma warning restore CS8625 // 无法将 null 文本转换为不可为 null 的引用类型。
                        };
                    }
                }
            }

            [Theory]
            [MemberData(nameof(NullReferenceTestData.Data), MemberType = typeof(NullReferenceTestData))]
            public void NullReference(SnowflakeID a, SnowflakeID b)
            {
                bool c = a == b;
                Assert.True(c);
            }

            /// <summary>
            /// 隐式转换测试
            /// </summary>
            [Fact]
            public void ImplicitLong()
            {
                SnowflakeID a = 10;
                SnowflakeID b = 10;

                Assert.True(a == b);
                Assert.True(a == 10);
                Assert.True(10 == b);

                ulong a1 = a;
                ulong b1 = b;
                Assert.True(a1 == b1);
                Assert.True(a1 == 10);
                Assert.True(10 == b1);
            }
        }
    }
}