using FreeID.Abstraction.ConstOrEnum.Enum;

namespace System
{
    public static class ULongExtensions
    {
        #region 转进制字符串

        /// <summary>
        /// 转换成2进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBinString(this ulong value)
        {
            return Convert.ToString((long)value, (int)NumberBaseEnum.Bin);
        }

        /// <summary>
        /// 转换成8进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToOctString(this ulong value)
        {
            return Convert.ToString((long)value, (int)NumberBaseEnum.Oct);
        }

        /// <summary>
        /// 转换成10进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDecString(this ulong value)
        {
            return Convert.ToString((long)value, (int)NumberBaseEnum.Dec);
        }

        /// <summary>
        /// 转换成16进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHexString(this ulong value)
        {
            return Convert.ToString((long)value, (int)NumberBaseEnum.Hex);
        }

        #endregion 转进制字符串
    }
}