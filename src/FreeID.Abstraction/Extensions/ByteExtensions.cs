using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class ByteExtensions
    {
        /// <summary>
        /// 对<see cref="byte"/>序列进行求和
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte Sum(this IEnumerable<byte> source)
        {
            return source.Aggregate((byte)0, (byte a, byte b) => (byte)(a + b));
        }
    }
}