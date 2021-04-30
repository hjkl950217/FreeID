﻿using System.Collections.Generic;
using System.Linq;
using FreeID.Abstraction.ConstOrEnum.Enum;

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

        #region 转进制字符串

        /// <summary>
        /// 转换成2进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBinString(this byte value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Bin);
        }

        /// <summary>
        /// 转换成8进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToOctString(this byte value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Oct);
        }

        /// <summary>
        /// 转换成10进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDecString(this byte value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Dec);
        }

        /// <summary>
        /// 转换成16进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHexString(this byte value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Hex);
        }

        #endregion 转进制字符串
    }
}