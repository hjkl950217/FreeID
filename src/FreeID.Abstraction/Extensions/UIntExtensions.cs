using FreeID.Abstraction.ConstOrEnum.Enum;

namespace System
{
    public static class UIntExtensions
    {
        #region 转进制字符串

        /// <summary>
        /// 转换成2进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBinString(this uint value)
        {
            return Convert.ToString((int)value, (int)NumberBaseEnum.Bin);
        }

        /// <summary>
        /// 转换成8进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToOctString(this uint value)
        {
            return Convert.ToString((int)value, (int)NumberBaseEnum.Oct);
        }

        /// <summary>
        /// 转换成10进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDecString(this uint value)
        {
            return Convert.ToString((int)value, (int)NumberBaseEnum.Dec);
        }

        /// <summary>
        /// 转换成16进制的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHexString(this uint value)
        {
            return Convert.ToString((int)value, (int)NumberBaseEnum.Hex);
        }

        #endregion 转进制字符串
    }
}