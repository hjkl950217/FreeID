﻿using FreeID.Abstraction.ConstOrEnum.Enum;

namespace System
{
    public static class ShortExtensions
    {
        #region 转进制字符串

        /// <summary>
        /// 转换成2进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBinString(this short value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Bin);
        }

        /// <summary>
        /// 转换成8进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToOctString(this short value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Oct);
        }

        /// <summary>
        /// 转换成10进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDecString(this short value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Dec);
        }

        /// <summary>
        /// 转换成16进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHexString(this short value)
        {
            return Convert.ToString(value, (int)NumberBaseEnum.Hex);
        }

        #endregion 转进制字符串
    }
}